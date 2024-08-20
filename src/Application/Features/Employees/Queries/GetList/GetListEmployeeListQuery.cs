using Application.Common.Pagination.Requests;
using Application.Common.Pagination.Responses;
using Application.Common.Pagination;
using Application.Common.Pipelines.Logging;
using AutoMapper;
using MediatR;
using Application.Services.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Application.Common.Pipelines.Caching;

namespace Application.Features.Employees.Queries.GetList;

public sealed record GetListEmployeeListQuery(PageRequest PageRequest) : IRequest<GetListResponse<GetListEmployeeListResponse>>, ICachableRequest, ILoggableRequest
{

    #region Cache
    public string CacheKey => $"GetListEmployeeListQuery({PageRequest.PageIndex},{PageRequest.PageSize})";

    public string? CacheGroupKey => "GetEmployees";

    public bool Bypass { get; }

    public TimeSpan? SlidingExpiration { get; }

    #endregion

    public sealed class GetListEmployeeQueryHandler(IEmployeeRepository employeeRepository, IMapper mapper) : IRequestHandler<GetListEmployeeListQuery, GetListResponse<GetListEmployeeListResponse>>
    {
        public async Task<GetListResponse<GetListEmployeeListResponse>> Handle(GetListEmployeeListQuery request, CancellationToken cancellationToken)
        {
            Paginate<Employee> employees = await employeeRepository.GetListAsync(
                orderBy: query => query.OrderByDescending(u => u.CreatedDate),
                include: p => p
                .Include(d => d.Department!)
                .Include(p => p.Position!),
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken);

            GetListResponse<GetListEmployeeListResponse> response = mapper.Map<GetListResponse<GetListEmployeeListResponse>>(employees);

            return response;
        }
    }
}