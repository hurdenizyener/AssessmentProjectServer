using Application.Common.Pipelines.Caching;
using Application.Common.Pipelines.Logging;
using Application.Features.Departments.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Departments.Commands.Update;

public sealed record UpdateDepartmentCommand(
    Guid Id,
    string Name) : IRequest<UpdatedDepartmentResponse>, ICacheRemoverRequest, ILoggableRequest
{

    #region CacheRemove
    public string? CacheKey => "";
    public string? CacheGroupKey => "GetDepartments";
    public bool Bypass => false;
    #endregion

    public sealed class UpdateDepartmentCommandHandler(IDepartmentRepository departmentRepository, IMapper mapper, DepartmentBusinessRules departmentBusinessRules) : IRequestHandler<UpdateDepartmentCommand, UpdatedDepartmentResponse>
    {
        public async Task<UpdatedDepartmentResponse> Handle(UpdateDepartmentCommand request, CancellationToken cancellationToken)
        {
            Department? department = await departmentBusinessRules.CheckIfDepartmentExists(request.Id, cancellationToken);
            await departmentBusinessRules.DepartmentNameShouldNotExistsWhenInsertAndUpdate(department!.Name, cancellationToken);

            department = mapper.Map(request, department);

            await departmentRepository.UpdateAsync(department!);

            UpdatedDepartmentResponse response = mapper.Map<UpdatedDepartmentResponse>(department);
            return response;
        }
    }
}
