using Application.Common.Pagination;
using Application.Common.Pagination.Responses;
using Application.Features.Positions.Commands.Create;
using Application.Features.Positions.Commands.Delete;
using Application.Features.Positions.Commands.Update;
using Application.Features.Positions.Queries.GetById;
using Application.Features.Positions.Queries.GetList;
using Application.Features.Positions.Queries.GetAllDepartmentPositions;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.Positions.Profiles;

public sealed class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Position, CreatedPositionResponse>().ReverseMap();
        CreateMap<Position, CreatePositionCommand>().ReverseMap();
        CreateMap<Position, DeletePositionCommand>().ReverseMap();
        CreateMap<Position, UpdatedPositionResponse>().ReverseMap();
        CreateMap<Position, UpdatePositionCommand>().ReverseMap();
        CreateMap<Position, GetByIdPositionResponse>().ReverseMap();
        CreateMap<Position, GetByIdPositionQuery>().ReverseMap();
        CreateMap<Position, GetListPositionListResponse>().ReverseMap();
        CreateMap<Paginate<Position>, GetListResponse<GetListPositionListResponse>>().ReverseMap();
        CreateMap<Position, GetAllDepartmentPositionListResponse>().ReverseMap();
        CreateMap<Paginate<Position>, GetListResponse<GetAllDepartmentPositionListResponse>>()
            .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items));

    }
}