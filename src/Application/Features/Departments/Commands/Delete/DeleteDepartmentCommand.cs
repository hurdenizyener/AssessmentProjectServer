using Application.Common.Pipelines.Caching;
using Application.Common.Pipelines.Logging;
using Application.Features.Departments.Constans;
using Application.Features.Departments.Rules;
using Application.Services.Repositories;
using Domain.Entities;
using MediatR;

namespace Application.Features.Departments.Commands.Delete;

public sealed record DeleteDepartmentCommand(Guid Id) : IRequest<DeletedDepartmentResponse>, ICacheRemoverRequest, ILoggableRequest
{
    #region CacheRemove
    public string? CacheKey => "";
    public string? CacheGroupKey => "GetDepartments";
    public bool Bypass => false;
    #endregion

    public sealed class DeleteDepartmentCommandHandler(IDepartmentRepository departmentRepository, DepartmentBusinessRules departmentBusinessRules) : IRequestHandler<DeleteDepartmentCommand, DeletedDepartmentResponse>
    {
        public async Task<DeletedDepartmentResponse> Handle(DeleteDepartmentCommand request, CancellationToken cancellationToken)
        {
            Department? department = await departmentBusinessRules.CheckIfDepartmentExists(request.Id, cancellationToken);

            await departmentRepository.DeleteAsync(department!);

            DeletedDepartmentResponse response = new(DepartmentMessages.DepartmentSuccessfullyDeleted);

            return response;
        }
    }
}