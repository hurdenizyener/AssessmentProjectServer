using Application.Common.Pipelines.Caching;
using Application.Common.Pipelines.Logging;
using Application.Features.Positions.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Positions.Commands.Create;

public sealed record CreatePositionCommand(
    Guid DepartmentId,
    string Title) : IRequest<CreatedPositionResponse>, ICacheRemoverRequest, ILoggableRequest
{
    #region CacheRemove
    public string? CacheKey => "";
    public string? CacheGroupKey => "GetPositions";
    public bool Bypass => false;
    #endregion

    public sealed class CreatePositionCommandHandler(IPositionRepository positionRepository, IMapper mapper, PositionBusinessRules positionBusinessRules) : IRequestHandler<CreatePositionCommand, CreatedPositionResponse>
    {
        public async Task<CreatedPositionResponse> Handle(CreatePositionCommand request, CancellationToken cancellationToken)
        {
            await positionBusinessRules.PositionTitleShouldNotExistsWhenInsertAndUpdate(request.DepartmentId, request.Title, cancellationToken);

            Position position = mapper.Map<Position>(request);

            await positionRepository.AddAsync(position);

            CreatedPositionResponse response = mapper.Map<CreatedPositionResponse>(position);
            return response;
        }
    }

}
