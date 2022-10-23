
using MovieWebApi.Contracts.Dto;
using MovieWebApi.Domain.Core.Entities;

namespace MovieWebApi.Services.Interfaces.Authentication
{
    public interface IAuthenticationManager
    {
        Task<bool> ValidateUser(UserAuthenticationDto userForAuth);
        Task<string> CreateToken();
        Task<User> GetUserAsync(string userName);
    }
}
