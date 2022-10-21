﻿using MovieWebApi.Domain.Interfaces.Repositories;
using MovieWebApi.Infrastructure.Data.Repositories.Repositories;

namespace MovieWebApi.Infrastructure.Data.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext;
        private IMovieRepository _movieRepository;
        private IStarringRepository _starringRepository;

        public IMovieRepository Movie
        {
            get
            {
                if (_movieRepository is null)
                    _movieRepository = new MovieRepository(_repositoryContext);
                return _movieRepository;
            }
        }

        public IStarringRepository Starring
        {
            get
            {
                if (_starringRepository is null)
                    _starringRepository = new StarringRepository(_repositoryContext);
                return _starringRepository;
            }
        }

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }
        public Task SaveAsync() => _repositoryContext.SaveChangesAsync();
    }
}
