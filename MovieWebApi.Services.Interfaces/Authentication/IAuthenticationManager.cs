
using MovieWebApi.Contracts.Dto;

namespace MovieWebApi.Services.Interfaces.Authentication
{
    public interface IAuthenticationManager
    {
        Task<bool> ValidateUser(UserAuthenticationDto userForAuth);
        Task<string> CreateToken();
    }
}
