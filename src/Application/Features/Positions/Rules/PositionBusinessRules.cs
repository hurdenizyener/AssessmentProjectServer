using Application.Common.Exceptions.Types;
using Application.Common.Rules;
using Application.Features.Positions.Constans;
using Application.Services.Repositories;
using Domain.Entities;

namespace Application.Features.Positions.Rules;

public sealed class PositionBusinessRules(IPositionRepository positionRepository) : BaseBusinessRules
{
    public async Task PositionTitleShouldNotExistsWhenInsertAndUpdate(Guid departmentId, string title, CancellationToken cancellationToken)
    {
        bool doesExist = await positionRepository.AnyAsync(
             predicate: p => p.DepartmentId == departmentId && p.Title == title,
             enableTracking: false,
             cancellationToken: cancellationToken);

        if (doesExist)
            throw new BusinessException(PositionBusinessExceptionMessages.PositionTitleAlreadyExists);
    }

    public async Task<Position> CheckIfPositionExists(Guid id, CancellationToken cancellationToken)
    {
        Position? position = await positionRepository.GetAsync(
            predicate: c => c.Id.Equals(id),
            cancellationToken: cancellationToken);

        return position is null ? throw new BusinessException(PositionBusinessExceptionMessages.PositionDontExists) : position;
    }
}