using AutoMapper;
using Domain.Entities;
using Application.Features.Employees.Commands.Create;
using Application.Features.Employees.Commands.Delete;
using Application.Features.Employees.Commands.Update;
using Application.Features.Employees.Queries.GetById;
using Application.Common.Pagination;
using Application.Features.Employees.Queries.GetList;
using Application.Common.Pagination.Responses;
using Application.Features.Employees.Commands.UpdateStatus;

namespace Application.Features.Employees.Profiles;

public sealed class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Employee, CreatedEmployeeResponse>().ReverseMap();
        CreateMap<Employee, CreateEmployeeCommand>().ReverseMap();
        CreateMap<Employee, DeleteEmployeeCommand>().ReverseMap();
        CreateMap<Employee, UpdatedEmployeeResponse>().ReverseMap();
        CreateMap<Employee, UpdateEmployeeCommand>().ReverseMap();
        CreateMap<Employee, UpdateStatusCommand>().ReverseMap();
        CreateMap<Employee, UpdatedStatusResponse>().ReverseMap();
        CreateMap<Employee, GetByIdEmployeeResponse>().ReverseMap();
        CreateMap<Employee, GetByIdEmployeeQuery>().ReverseMap();
        CreateMap<Employee, GetListEmployeeListResponse>().ReverseMap();
        CreateMap<Paginate<Employee>, GetListResponse<GetListEmployeeListResponse>>().ReverseMap();

    }
}