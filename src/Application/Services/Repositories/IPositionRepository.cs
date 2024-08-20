using Application.Common.Repositories.Abstractions;
using Domain.Entities;

namespace Application.Services.Repositories;

public interface IPositionRepository : IAsyncRepository<Position> { }