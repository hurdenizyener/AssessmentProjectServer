using Application.Common.Pipelines.Logging;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Employees.Queries.GetById;

public sealed record GetByIdEmployeeQuery(Guid Id) : IRequest<GetByIdEmployeeResponse>, ILoggableRequest
{
    public sealed class GetByIdEmployeeQueryHandler(IEmployeeRepository employeeRepository, IMapper mapper) : IRequestHandler<GetByIdEmployeeQuery, GetByIdEmployeeResponse>
    {
        public async Task<GetByIdEmployeeResponse> Handle(GetByIdEmployeeQuery request, CancellationToken cancellationToken)
        {
            Employee? employee = await employeeRepository.GetAsync(
                predicate: p => p.Id == request.Id,
                include: p => p
                .Include(d => d.Department!)
                .Include(p => p.Position!),
                cancellationToken: cancellationToken);

            GetByIdEmployeeResponse response = mapper.Map<GetByIdEmployeeResponse>(employee);
            return response;
        }
    }
}