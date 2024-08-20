using Application.Common.Pagination.Requests;
using Application.Common.Pagination.Responses;
using Application.Common.Pagination;
using Application.Common.Pipelines.Caching;
using Application.Common.Pipelines.Logging;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Positions.Queries.GetList;

public sealed record GetListPositionListQuery(PageRequest PageRequest) : IRequest<GetListResponse<GetListPositionListResponse>>, ICachableRequest, ILoggableRequest
{

    #region Cache
    public string CacheKey => $"GetListPositionListQuery({PageRequest.PageIndex},{PageRequest.PageSize})";

    public string? CacheGroupKey => "GetPositions";

    public bool Bypass { get; }

    public TimeSpan? SlidingExpiration { get; }

    #endregion

    public sealed class GetListPositionListQueryHandler(IPositionRepository positionRepository, IMapper mapper) : IRequestHandler<GetListPositionListQuery, GetListResponse<GetListPositionListResponse>>
    {
        public async Task<GetListResponse<GetListPositionListResponse>> Handle(GetListPositionListQuery request, CancellationToken cancellationToken)
        {
            Paginate<Position> position = await positionRepository.GetListAsync(
                orderBy: query => query.OrderByDescending(u => u.CreatedDate),
                include: p => p.Include(d => d.Department!),
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken);

            GetListResponse<GetListPositionListResponse> response = mapper.Map<GetListResponse<GetListPositionListResponse>>(position);

            return response;
        }
    }
}