namespace MovieWebApi.Services.Interfaces
{
    public interface IServiceManager
    {
        IMovieService movieService { get; }
        IStarringService starringService { get; }
    }
}