
using AutoMapper;
using MovieWebApi.Domain.Core.Entities;

namespace MovieWebApi.Contracts.Dto.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Movie, MovieDto>().ReverseMap();
        }
    }
}
