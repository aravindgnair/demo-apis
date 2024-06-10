using AutoMapper;
using Demo.AuthJwt.Data.Models;
using Demo.AuthJwt.Dto;

namespace Demo.AuthJwt.Helpers;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<NewUserDto, User>()
            .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password.EncryptString()));
    }
}