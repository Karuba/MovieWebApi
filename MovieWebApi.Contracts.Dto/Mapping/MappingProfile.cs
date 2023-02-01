
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
                Id = Guid.Parse(x.Id),
            })));
            CreateMap<MovieCreateDto, Movie>().ForMember(c => c.Id, opt => opt.MapFrom(x => Guid.NewGuid().ToString()));
            CreateMap<Movie, MovieUpdateDto>().ReverseMap();
            CreateMap<Starring, StarringDto>().ReverseMap();
            CreateMap<Starring, StarringCreateDto>().ReverseMap();
            CreateMap<Starring, StarringUpdateDto>().ReverseMap();
            CreateMap<User, UserRegistrationDto>().ReverseMap();
            CreateMap<UserRating, UserRatingUpdateDto>().ReverseMap();
            CreateMap<User, UserDto>();
        }
    }
}
