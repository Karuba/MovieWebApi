﻿
namespace MovieWebApi.Domain.Interfaces.Repositories
{
    public interface IRepositoryManager
    {
        IMovieRepository Movie { get; }
        IStarringRepository Starring { get; }
        Task SaveAsync();
    }
}
