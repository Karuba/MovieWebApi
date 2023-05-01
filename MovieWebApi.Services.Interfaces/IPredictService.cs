
using MovieWebApi.Contracts.Dto;
using MovieWebApi.Domain.Core.Entities;
using MovieWebApi.Domain.Interfaces.RequestFeatures;

namespace MovieWebApi.Services.Interfaces
{
    public interface IPredictService
    {
        Task<IEnumerable<MovieDto>> GetUserRecommendation(User user);
    }
}
