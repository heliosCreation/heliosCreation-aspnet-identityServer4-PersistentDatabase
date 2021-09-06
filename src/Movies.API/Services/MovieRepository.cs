using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Movies.API.Data;
using Movies.API.Data.Entities;
using Movies.API.Model.Movies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.API.Services
{
    public class MovieRepository : IMovieRepository
    {
        private readonly MoviesContext _context;
        private readonly ILoggedInUserService _user;

        public MovieRepository(MoviesContext context, ILoggedInUserService user)
        {
            _context = context;
            _user = user;
        }


        public async Task<Movie> GetMovie(Guid id)
        {
            return await _context.Movie.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<IReadOnlyList<Movie>> GetMovies()
        {
            return await _context.Movie.Where(m => m.OwnerId == _user.getUserId()).ToListAsync();
        }

        public async Task<Movie> CreateMovie(Movie movie)
        {
            _context.Movie.Add(movie);
            await _context.SaveChangesAsync();
            return movie;
        }
        public async Task UpdateMovie(Movie movie)
        {
            _context.Movie.Update(movie);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMovie(Movie movie)
        {
            _context.Movie.Remove(movie);
            await _context.SaveChangesAsync();
        }
    }
}
