using MovieWebApi.Services.Interfaces.Authentication;

namespace MovieWebApi.Services.Interfaces
{
    public interface IServiceManager
    {
        IMovieService movieService { get; }
        IStarringService starringService { get; }
        IAuthenticationManager authenticationManager { get; }
    }
}