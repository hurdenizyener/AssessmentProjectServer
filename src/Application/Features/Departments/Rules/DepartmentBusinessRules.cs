using Application.Common.Exceptions.Types;
using Application.Common.Rules;
using Application.Features.Departments.Constans;
using Application.Services.Repositories;
using Domain.Entities;

namespace Application.Features.Departments.Rules;

public sealed class DepartmentBusinessRules(IDepartmentRepository departmentRepository) : BaseBusinessRules
{
    public async Task DepartmentNameShouldNotExistsWhenInsertAndUpdate(string name, CancellationToken cancellationToken)
    {
        bool doesExist = await departmentRepository.AnyAsync(
             predicate: d => d.Name == name,
             cancellationToken: cancellationToken);

        if (doesExist)
            throw new BusinessException(DepartmentBusinessExceptionMessages.DepartmentNameAlreadyExists);
    }

    public async Task<Department> CheckIfDepartmentExists(Guid id, CancellationToken cancellationToken)
    {
        Department? department = await departmentRepository.GetAsync(
            predicate: c => c.Id.Equals(id),
            cancellationToken: cancellationToken);

        return department is null ? throw new BusinessException(DepartmentBusinessExceptionMessages.DepartmentDontExists) : department;
    }
}