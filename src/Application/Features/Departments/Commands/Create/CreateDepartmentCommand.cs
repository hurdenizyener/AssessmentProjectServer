using Application.Common.Pipelines.Caching;
using Application.Common.Pipelines.Logging;
using Application.Features.Departments.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Departments.Commands.Create;

public sealed record CreateDepartmentCommand(string Name) : IRequest<CreatedDepartmentResponse>, ICacheRemoverRequest, ILoggableRequest
{

    #region CacheRemove
    public string? CacheKey => "";
    public string? CacheGroupKey => "GetDepartments";
    public bool Bypass => false;
    #endregion

    public sealed class CreateDepartmentCommandHandler(IDepartmentRepository departmentRepository, IMapper mapper, DepartmentBusinessRules departmentBusinessRules) : IRequestHandler<CreateDepartmentCommand, CreatedDepartmentResponse>
    {
        public async Task<CreatedDepartmentResponse> Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
        {
            await departmentBusinessRules.DepartmentNameShouldNotExistsWhenInsertAndUpdate(request.Name, cancellationToken);

            Department department = mapper.Map<Department>(request);

            await departmentRepository.AddAsync(department);

            CreatedDepartmentResponse response = mapper.Map<CreatedDepartmentResponse>(department);
            return response;
        }
    }

}