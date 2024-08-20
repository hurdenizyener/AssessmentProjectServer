using Application.Common.Repositories;
using Application.Services.Repositories;
using Domain.Entities;
using Infrastructure.Persistence.Contexts;

namespace Infrastructure.Repositories;

public sealed class EmployeeRepository(AppDbContext context) : EfRepositoryBase<Employee, AppDbContext>(context), IEmployeeRepository
{
}
