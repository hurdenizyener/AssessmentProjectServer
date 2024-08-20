using Application.Common.Pipelines.Caching;
using Application.Common.Pipelines.Logging;
using Application.Features.Positions.Constans;
using Application.Features.Positions.Rules;
using Application.Services.Repositories;
using Domain.Entities;
using MediatR;

namespace Application.Features.Positions.Commands.Delete;

public sealed record DeletePositionCommand(Guid Id) : IRequest<DeletedPositionResponse>, ICacheRemoverRequest, ILoggableRequest
{
    #region CacheRemove
    public string? CacheKey => "";
    public string? CacheGroupKey => "GetPositions";
    public bool Bypass => false;
    #endregion

    public sealed class DeletePositionCommandHandler(IPositionRepository positionRepository, PositionBusinessRules positionBusinessRules) : IRequestHandler<DeletePositionCommand, DeletedPositionResponse>
    {
        public async Task<DeletedPositionResponse> Handle(DeletePositionCommand request, CancellationToken cancellationToken)
        {
            Position? position = await positionBusinessRules.CheckIfPositionExists(request.Id, cancellationToken);

            await positionRepository.DeleteAsync(position!);

            DeletedPositionResponse response = new(PositionMessages.PositionSuccessfullyDeleted);

            return response;
        }
    }
}