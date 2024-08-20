using AutoMapper;
using Domain.Entities;
using Application.Features.Departments.Commands.Create;
using Application.Features.Departments.Commands.Delete;
using Application.Features.Departments.Commands.Update;
using Application.Features.Departments.Queries.GetById;
using Application.Features.Departments.Queries.GetList;
using Application.Common.Pagination;
using Application.Common.Pagination.Responses;
using Application.Features.Departments.Queries.GetAll;

namespace Application.Features.Departments.Profiles;

public sealed class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Department, CreatedDepartmentResponse>().ReverseMap();
        CreateMap<Department, CreateDepartmentCommand>().ReverseMap();
        CreateMap<Department, DeleteDepartmentCommand>().ReverseMap();
        CreateMap<Department, UpdatedDepartmentResponse>().ReverseMap();
        CreateMap<Department, UpdateDepartmentCommand>().ReverseMap();
        CreateMap<Department, GetByIdDepartmentResponse>().ReverseMap();
        CreateMap<Department, GetByIdDepartmentQuery>().ReverseMap();
        CreateMap<Department, GetListDepartmentListResponse>().ReverseMap();
        CreateMap<Paginate<Department>, GetListResponse<GetListDepartmentListResponse>>().ReverseMap();
        CreateMap<Department, GetAllDepartmentListResponse>().ReverseMap();
        CreateMap<Paginate<Department>, GetListResponse<GetAllDepartmentListResponse>>()
           .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items));

    }
}