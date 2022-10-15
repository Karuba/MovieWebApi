namespace MovieWebApi.Services.Interfaces
{
    public interface IServiceManager
    {
        IMovieService movieService { get; }
    }
}