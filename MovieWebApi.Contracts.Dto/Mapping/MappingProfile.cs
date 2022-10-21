
using AutoMapper;
using MovieWebApi.Domain.Core.Entities;

namespace MovieWebApi.Contracts.Dto.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Movie, MovieDto>().ForMember(c => c.Starrings, opt => opt.MapFrom(x => x.MovieStarrings.Select(x => x.Starring).Select(x => new StarringDto
            {
                Description = x.Description,
                FirstName = x.FirstName,
                SecondName = x.SecondName,
                Id = x.Id,
            })));
            CreateMap<Movie, MovieCreateDto>().ReverseMap();
            CreateMap<Movie, MovieUpdateDto>().ReverseMap();
            CreateMap<Starring, StarringDto>().ReverseMap();
            CreateMap<Starring, StarringCreateDto>().ReverseMap();
            CreateMap<Starring, StarringUpdateDto>().ReverseMap();
            CreateMap<User, UserRegistrationDto>().ReverseMap();
        }
    }
}
