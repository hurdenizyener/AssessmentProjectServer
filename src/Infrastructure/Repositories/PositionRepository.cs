using Application.Common.Repositories;
using Application.Services.Repositories;
using Domain.Entities;
using Infrastructure.Persistence.Contexts;
namespace Infrastructure.Repositories;

public sealed class PositionRepository(AppDbContext context) : EfRepositoryBase<Position, AppDbContext>(context), IPositionRepository
{
}