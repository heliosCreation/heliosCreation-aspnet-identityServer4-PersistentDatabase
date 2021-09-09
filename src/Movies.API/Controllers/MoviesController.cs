using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Movies.API.Data.Entities;
using Movies.API.Model.Movies;
using Movies.API.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Movies.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize("ClientIdPolicy")]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieRepository _movieRepository;
        private readonly ILoggedInUserService _user;
        private readonly IMapper _mapper;

        public MoviesController(IMovieRepository movieRepository, ILoggedInUserService user, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _user = user;
            _mapper = mapper;
        }

        // GET: api/Movies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieModel>>> GetMovies()
        {
            return Ok(await _movieRepository.GetMovies());
        }

        // GET: api/Movies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MovieModel>> GetMovie(Guid id)
        {

            var movie = await _movieRepository.GetMovie(id);

            if (movie == null)
            {
                return NotFound();
            }
            var result = _mapper.Map<MovieModel>(movie);

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<MovieModel>> PostMovie(MovieCreationModel movie)
        {
            var movieForRepo = _mapper.Map<Movie>(movie);
            movieForRepo.OwnerId = _user.getUserSub();
            var createdMovie = await _movieRepository.CreateMovie(movieForRepo);
            return CreatedAtAction("GetMovie", new { id = createdMovie.Id }, movie);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovie(Guid id, MovieUpdateModel movie)
        {
            var repoMovie = await _movieRepository.GetMovie(id);
            if (repoMovie == null)
            {
                return NotFound();
            }
            await _movieRepository.UpdateMovie(_mapper.Map(movie, repoMovie));
            return NoContent();
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(MovieDeleteModel deleteModel)
        {
            var repoMovie = await _movieRepository.GetMovie(deleteModel.Id);
            if (repoMovie == null)
            {
                return NotFound();
            }
            await _movieRepository.DeleteMovie(repoMovie);
            return NoContent();
        }


    }
}
