using Movies.API.Data.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Movies.API.Services
{
    public interface IMovieRepository
    {
        Task<Movie> GetMovie(Guid id);
        Task<IReadOnlyList<Movie>> GetMovies();
        Task<Movie> CreateMovie(Movie movie);
        Task UpdateMovie(Movie movie);
        Task DeleteMovie(Movie movie);
    }
}
