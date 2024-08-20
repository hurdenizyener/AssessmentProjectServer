using Application.Common.Pipelines.Caching;
using Application.Common.Pipelines.Logging;
using Application.Features.Employees.Constans;
using Application.Features.Employees.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Employees.Commands.UpdateStatus;

public sealed record UpdateStatusCommand(
   Guid Id,
   bool Status) : IRequest<UpdatedStatusResponse>, ICacheRemoverRequest, ILoggableRequest
{
    #region CacheRemove
    public string? CacheKey => "";
    public string? CacheGroupKey => "GetEmployees";
    public bool Bypass => false;
    #endregion

    public sealed class UpdateStatusCommandHandler(IEmployeeRepository employeeRepository, IMapper mapper, EmployeeBusinessRules employeeBusinessRules) : IRequestHandler<UpdateStatusCommand, UpdatedStatusResponse>
    {
        public async Task<UpdatedStatusResponse> Handle(UpdateStatusCommand request, CancellationToken cancellationToken)
        {

            Employee? employee = await employeeBusinessRules.CheckIfEmployeeExists(request.Id, cancellationToken);

            employee = mapper.Map(request, employee);
            employee.Status = request.Status;

            await employeeRepository.UpdateAsync(employee!);

            UpdatedStatusResponse response = new(EmployeeMessages.StatusSuccessfullyUpdated);

            return response;
        }
    }
}