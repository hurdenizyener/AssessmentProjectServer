using Application.Common.Pagination.Requests;
using Application.Common.Pagination.Responses;
using Application.Common.Pagination;
using Application.Common.Pipelines.Caching;
using Application.Common.Pipelines.Logging;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;


namespace Application.Features.Positions.Queries.GetAllDepartmentPositions;

public sealed record GetAllDepartmentPositionListQuery(Guid DepartmentId) : IRequest<List<GetAllDepartmentPositionListResponse>>, ICachableRequest, ILoggableRequest
{

    #region Cache
    public string CacheKey => $"GetAllDepartmentPositionListQuery({DepartmentId})";

    public string? CacheGroupKey => "GetPositions";

    public bool Bypass { get; }

    public TimeSpan? SlidingExpiration { get; }

    #endregion

    public sealed class GetAllDepartmentPositionListQueryHandler(IPositionRepository positionRepository, IMapper mapper) : IRequestHandler<GetAllDepartmentPositionListQuery, List<GetAllDepartmentPositionListResponse>>
    {
        public async Task<List<GetAllDepartmentPositionListResponse>> Handle(GetAllDepartmentPositionListQuery request, CancellationToken cancellationToken)
        {
            List<Position> positionList = await positionRepository.GetAllAsync(
                orderBy: query => query.OrderByDescending(u => u.CreatedDate),
                predicate:p=>p.DepartmentId.Equals(request.DepartmentId),
                cancellationToken: cancellationToken);

            List<GetAllDepartmentPositionListResponse> response = mapper.Map<List<GetAllDepartmentPositionListResponse>>(positionList);

            return response;
        }
    }
}