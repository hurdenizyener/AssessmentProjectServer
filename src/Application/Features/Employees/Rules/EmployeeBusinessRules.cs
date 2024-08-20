using Application.Common.Exceptions.Types;
using Application.Common.Rules;
using Application.Features.Employees.Constans;
using Application.Services.Repositories;
using Domain.Entities;

namespace Application.Features.Employees.Rules;

public sealed class EmployeeBusinessRules(IEmployeeRepository employeeRepository) : BaseBusinessRules
{
    public async Task EmployeeEmailShouldNotExistsWhenInsert(string email, CancellationToken cancellationToken)
    {
        bool doesExist = await employeeRepository.AnyAsync(
             predicate: e => e.Email == email,
             cancellationToken: cancellationToken);

        if (doesExist)
            throw new BusinessException(EmployeeBusinessExceptionMessages.EmployeeEmailAlreadyExists);
    }

    public async Task<Employee> CheckIfEmployeeExists(Guid id, CancellationToken cancellationToken)
    {
        Employee? employee = await employeeRepository.GetAsync(
            predicate: c => c.Id.Equals(id),
            cancellationToken: cancellationToken);

        return employee is null ? throw new BusinessException(EmployeeBusinessExceptionMessages.EmployeeDontExists) : employee;
    }

    public async Task EmployeeEmailShouldNotExistsWhenUpdate(Guid id, string email, CancellationToken cancellationToken)
    {
        bool doesExists = await employeeRepository.AnyAsync(
            predicate: u => u.Id != id && u.Email == email,
            cancellationToken: cancellationToken);

        if (doesExists)
            throw new BusinessException(EmployeeBusinessExceptionMessages.EmployeeEmailAlreadyExists);
    }
}
