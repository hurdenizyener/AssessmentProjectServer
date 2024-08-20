using Application.Common.Pipelines.Logging;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Positions.Queries.GetById;

public sealed record GetByIdPositionQuery(Guid Id) : IRequest<GetByIdPositionResponse>, ILoggableRequest
{
    public sealed class GetByIdPositionQueryHandler(IPositionRepository positionRepository, IMapper mapper) : IRequestHandler<GetByIdPositionQuery, GetByIdPositionResponse>
    {
        public async Task<GetByIdPositionResponse> Handle(GetByIdPositionQuery request, CancellationToken cancellationToken)
        {
            Position? position = await positionRepository.GetAsync(
                predicate: p => p.Id == request.Id,
                include: p => p
                .Include(d => d.Department!),
                cancellationToken: cancellationToken);

            GetByIdPositionResponse response = mapper.Map<GetByIdPositionResponse>(position);
            return response;
        }
    }
}