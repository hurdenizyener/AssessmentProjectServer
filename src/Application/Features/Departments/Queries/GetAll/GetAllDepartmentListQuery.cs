using Application.Common.Pagination.Responses;
using Application.Common.Pipelines.Caching;
using Application.Common.Pipelines.Logging;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Departments.Queries.GetAll;

public sealed record GetAllDepartmentListQuery() : IRequest<List<GetAllDepartmentListResponse>>, ICachableRequest, ILoggableRequest
{

    #region Cache
    public string CacheKey => $"GetAllDepartmentListQuery()";

    public string? CacheGroupKey => "GetDepartments";

    public bool Bypass { get; }

    public TimeSpan? SlidingExpiration { get; }

    #endregion

    public sealed class GetAllDepartmentListQueryHandler(IDepartmentRepository departmentRepository, IMapper mapper) : IRequestHandler<GetAllDepartmentListQuery, List<GetAllDepartmentListResponse>>
    {
        public async Task<List<GetAllDepartmentListResponse>> Handle(GetAllDepartmentListQuery request, CancellationToken cancellationToken)
        {
            List<Department> department = await departmentRepository.GetAllAsync(
                orderBy: query => query.OrderByDescending(u => u.CreatedDate),
                cancellationToken: cancellationToken);

            List<GetAllDepartmentListResponse> response = mapper.Map<List<GetAllDepartmentListResponse>>(department);

            return response;
        }
    }
}