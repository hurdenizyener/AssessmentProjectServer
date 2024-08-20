using Application.Common.Pipelines.Logging;
using AutoMapper;
using MediatR;
using Application.Services.Repositories;
using Domain.Entities;
using Application.Features.Employees.Rules;
using Application.Common.Pipelines.Caching;

namespace Application.Features.Employees.Commands.Create;

public sealed record CreateEmployeeCommand(
    Guid DepartmentId,
    Guid PositionId,
    string FirstName,
    string LastName,
    string Gender,
    string Phone,
    string Email,
    string GraduatedSchool,
    string GraduatedField,
    DateTime BirthDate,
    DateTime DateOfEntry,
    bool Asset,
    string? Address) : IRequest<CreatedEmployeeResponse>, ICacheRemoverRequest, ILoggableRequest
{

    #region CacheRemove
    public string? CacheKey => "";
    public string? CacheGroupKey => "GetEmployees";
    public bool Bypass => false;
    #endregion


    public sealed class CreateEmployeeCommandHandler(IEmployeeRepository employeeRepository, IMapper mapper, EmployeeBusinessRules employeeBusinessRules) : IRequestHandler<CreateEmployeeCommand, CreatedEmployeeResponse>
    {
        public async Task<CreatedEmployeeResponse> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            await employeeBusinessRules.EmployeeEmailShouldNotExistsWhenInsert(request.Email, cancellationToken);

            Employee employee = mapper.Map<Employee>(request);
            employee.Status = true;

            await employeeRepository.AddAsync(employee);

            CreatedEmployeeResponse response = mapper.Map<CreatedEmployeeResponse>(employee);
            return response;
        }
    }

}
