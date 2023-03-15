using AutoMapper;
using CrudSample.Core.DTOs;
using CrudSample.Core.Models;

namespace CrudSample.Service.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Users, UserDto>().ReverseMap();
            CreateMap<Users, UserUpdateDto>().ReverseMap();
        }
    }
}
