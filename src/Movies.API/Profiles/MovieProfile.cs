using AutoMapper;
using Movies.API.Data.Entities;
using Movies.API.Model.Movies;

namespace Movies.API.Profiles
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<MovieCreationModel, Movie>();

            CreateMap<MovieUpdateModel, Movie>();

            CreateMap<Movie, MovieModel>();
        }
    }
}
