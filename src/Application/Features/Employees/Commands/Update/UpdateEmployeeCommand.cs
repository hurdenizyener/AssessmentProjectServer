using Application.Common.Pipelines.Caching;
using Application.Common.Pipelines.Logging;
using Application.Features.Employees.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Employees.Commands.Update;

public sealed record UpdateEmployeeCommand(
    Guid Id,
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
    string? Address,
    bool Status) : IRequest<UpdatedEmployeeResponse>, ICacheRemoverRequest, ILoggableRequest
{

    #region CacheRemove
    public string? CacheKey => "";
    public string? CacheGroupKey => "GetEmployees";
    public bool Bypass => false;
    #endregion

    public sealed class UpdateEmployeeCommandHandler(IEmployeeRepository employeeRepository, IMapper mapper, EmployeeBusinessRules employeeBusinessRules) : IRequestHandler<UpdateEmployeeCommand, UpdatedEmployeeResponse>
    {
        public async Task<UpdatedEmployeeResponse> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            Employee? employee = await employeeBusinessRules.CheckIfEmployeeExists(request.Id, cancellationToken);
            await employeeBusinessRules.EmployeeEmailShouldNotExistsWhenUpdate(employee!.Id, request.Email, cancellationToken);

            employee = mapper.Map(request, employee);

            await employeeRepository.UpdateAsync(employee!);

            UpdatedEmployeeResponse response = mapper.Map<UpdatedEmployeeResponse>(employee);
            return response;
        }
    }
}
