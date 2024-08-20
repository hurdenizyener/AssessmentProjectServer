using Application.Common.Pipelines.Caching;
using Application.Common.Pipelines.Logging;
using Application.Features.Positions.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Positions.Commands.Update;

public sealed record UpdatePositionCommand(
    Guid Id,
    Guid DepartmentId,
    string Title) : IRequest<UpdatedPositionResponse>, ICacheRemoverRequest, ILoggableRequest
{

    #region CacheRemove
    public string? CacheKey => "";
    public string? CacheGroupKey => "GetPositions";
    public bool Bypass => false;
    #endregion

    public sealed class UpdatePositionCommandHandler(IPositionRepository positionRepository, IMapper mapper, PositionBusinessRules positionBusinessRules) : IRequestHandler<UpdatePositionCommand, UpdatedPositionResponse>
    {
        public async Task<UpdatedPositionResponse> Handle(UpdatePositionCommand request, CancellationToken cancellationToken)
        {
            Position? position = await positionBusinessRules.CheckIfPositionExists(request.Id, cancellationToken);
            await positionBusinessRules.PositionTitleShouldNotExistsWhenInsertAndUpdate(position!.DepartmentId, position!.Title, cancellationToken);

            position = mapper.Map(request, position);

            await positionRepository.UpdateAsync(position!);

            UpdatedPositionResponse response = mapper.Map<UpdatedPositionResponse>(position);
            return response;
        }
    }
}
