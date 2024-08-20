using Application.Common.Pagination.Requests;
using Application.Common.Pagination.Responses;
using Application.Common.Pagination;
using Application.Common.Pipelines.Caching;
using Application.Common.Pipelines.Logging;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Departments.Queries.GetList;

public sealed record GetListDepartmentListQuery(PageRequest PageRequest) : IRequest<GetListResponse<GetListDepartmentListResponse>>, ICachableRequest, ILoggableRequest
{

    #region Cache
    public string CacheKey => $"GetListDepartmentListQuery({PageRequest.PageIndex},{PageRequest.PageSize})";

    public string? CacheGroupKey => "GetDepartments";

    public bool Bypass { get; }

    public TimeSpan? SlidingExpiration { get; }

    #endregion

    public sealed class GetListDepartmentListQueryHandler(IDepartmentRepository departmentRepository, IMapper mapper) : IRequestHandler<GetListDepartmentListQuery, GetListResponse<GetListDepartmentListResponse>>
    {
        public async Task<GetListResponse<GetListDepartmentListResponse>> Handle(GetListDepartmentListQuery request, CancellationToken cancellationToken)
        {
            Paginate<Department> department = await departmentRepository.GetListAsync(
                orderBy: query => query.OrderByDescending(u => u.CreatedDate),
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken);

            GetListResponse<GetListDepartmentListResponse> response = mapper.Map<GetListResponse<GetListDepartmentListResponse>>(department);

            return response;
        }
    }
}