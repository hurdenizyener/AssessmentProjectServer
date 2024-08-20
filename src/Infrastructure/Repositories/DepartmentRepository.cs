using Application.Common.Repositories;
using Application.Services.Repositories;
using Domain.Entities;
using Infrastructure.Persistence.Contexts;
namespace Infrastructure.Repositories;

public sealed class DepartmentRepository(AppDbContext context) : EfRepositoryBase<Department, AppDbContext>(context), IDepartmentRepository
{
}
