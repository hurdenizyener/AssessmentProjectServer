using Application.Common.Pipelines.Logging;
using MediatR;
using Application.Services.Repositories;
using Application.Features.Employees.Rules;
using Domain.Entities;
using Application.Features.Employees.Constans;
using Application.Common.Pipelines.Caching;

namespace Application.Features.Employees.Commands.Delete;

public sealed record DeleteEmployeeCommand(Guid Id) : IRequest<DeletedEmployeeResponse>, ICacheRemoverRequest, ILoggableRequest
{
    #region CacheRemove
    public string? CacheKey => "";
    public string? CacheGroupKey => "GetEmployees";
    public bool Bypass => false;
    #endregion

    public sealed class DeleteEmployeeCommandHandler(IEmployeeRepository employeeRepository, EmployeeBusinessRules employeeBusinessRules) : IRequestHandler<DeleteEmployeeCommand, DeletedEmployeeResponse>
    {
        public async Task<DeletedEmployeeResponse> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            Employee? employee = await employeeBusinessRules.CheckIfEmployeeExists(request.Id, cancellationToken);

            await employeeRepository.DeleteAsync(employee!);

            DeletedEmployeeResponse response = new(EmployeeMessages.EmployeeSuccessfullyDeleted);

            return response;
        }
    }
}