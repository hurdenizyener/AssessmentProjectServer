using Application.Common.Pipelines.Logging;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Departments.Queries.GetById;

public sealed record GetByIdDepartmentQuery(Guid Id) : IRequest<GetByIdDepartmentResponse>, ILoggableRequest
{
    public sealed class GetByIdDepartmentQueryHandler(IDepartmentRepository departmentRepository, IMapper mapper) : IRequestHandler<GetByIdDepartmentQuery, GetByIdDepartmentResponse>
    {
        public async Task<GetByIdDepartmentResponse> Handle(GetByIdDepartmentQuery request, CancellationToken cancellationToken)
        {
            Department? department = await departmentRepository.GetAsync(
                predicate: p => p.Id == request.Id,
                cancellationToken: cancellationToken);

            GetByIdDepartmentResponse response = mapper.Map<GetByIdDepartmentResponse>(department);
            return response;
        }
    }
}