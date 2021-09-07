using Microsoft.Extensions.Logging;
using Movies.API.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.API.Data
{
    public class MovieContextSeed
    {
        public static async Task SeedAsync(MoviesContext moviesContext, ILogger<MovieContextSeed> logger)
        {
            if (!moviesContext.Movie.Any())
            {
                moviesContext.Movie.AddRange(GetPreconfiguredMovies());
                await moviesContext.SaveChangesAsync();
                logger.LogInformation("Seed movies for database associated with context {DbContextName}", typeof(MoviesContext).Name);
            }
            if (!moviesContext.ApplicationUserProfiles.Any())
            {
                moviesContext.ApplicationUserProfiles.AddRange(GetPreconfiguredProfiles());
                await moviesContext.SaveChangesAsync();
                logger.LogInformation("Seed user profiles for database associated with context {DbContextName}", typeof(MoviesContext).Name);
            }
        }

        private static IEnumerable<Movie> GetPreconfiguredMovies()
        {
            return new List<Movie>
            {
                    new Movie
                    {
                        Id = Guid.NewGuid(),
                        Genre = "Drama",
                        Title = "The Shawshank Redemption",
                        Rating = "9.3",
                        ImageUrl = "images/src",
                        ReleaseDate = new DateTime(1994, 5, 5),
                        OwnerId = "5BE86359-073C-434B-AD2D-A3932222DABE"
                    },
                    new Movie
                    {
                        Id = Guid.NewGuid(),
                        Genre = "Crime",
                        Title = "The Godfather",
                        Rating = "9.2",
                        ImageUrl = "images/src",
                        ReleaseDate = new DateTime(1972, 5, 5),
                        OwnerId = "5BE86359-073C-434B-AD2D-A3932222DABE"
                    },
                    new Movie
                    {
                        Id = Guid.NewGuid(),
                        Genre = "Action",
                        Title = "The Dark Knight",
                        Rating = "9.1",
                        ImageUrl = "images/src",
                        ReleaseDate = new DateTime(2008, 5, 5),
                        OwnerId = "5BE86359-073C-434B-AD2D-A3932222DABE"
                    },
                    new Movie
                    {
                        Id = Guid.NewGuid(),
                        Genre = "Crime",
                        Title = "12 Angry Men",
                        Rating = "8.9",
                        ImageUrl = "images/src",
                        ReleaseDate = new DateTime(1957, 5, 5),
                        OwnerId = "5BE86359-073C-434B-AD2D-A3932222DABE"
                    },
                    new Movie
                    {
                        Id = Guid.NewGuid(),
                        Genre = "Biography",
                        Title = "Schindler's List",
                        Rating = "8.9",
                        ImageUrl = "images/src",
                        ReleaseDate = new DateTime(1993, 5, 5),
                        OwnerId = "5BE86359-073C-434B-AD2D-A3932222DABE"
                    },
                    new Movie
                    {
                        Id = Guid.NewGuid(),
                        Genre = "Drama",
                        Title = "Pulp Fiction",
                        Rating = "8.9",
                        ImageUrl = "images/src",
                        ReleaseDate = new DateTime(1994, 5, 5),
                        OwnerId = "d860efca-22d9-47fd-8249-791ba61b07c7"
                    },
                    new Movie
                    {
                        Id = Guid.NewGuid(),
                        Genre = "Drama",
                        Title = "Fight Club",
                        Rating = "8.8",
                        ImageUrl = "images/src",
                        ReleaseDate = new DateTime(1999, 5, 5),
                        OwnerId = "d860efca-22d9-47fd-8249-791ba61b07c7"
                    },
                    new Movie
                    {
                        Id = Guid.NewGuid(),
                        Genre = "Romance",
                        Title = "Forrest Gump",
                        Rating = "8.8",
                        ImageUrl = "images/src",
                        ReleaseDate = new DateTime(1994, 5, 5),
                        OwnerId = "d860efca-22d9-47fd-8249-791ba61b07c7"
                    }
            };
        }

        private static IEnumerable<ApplicationUserProfile> GetPreconfiguredProfiles()
        {
            return new List<ApplicationUserProfile>
            {
                new ApplicationUserProfile
                {
                    Id = Guid.NewGuid(),
                    Subject = "5BE86359-073C-434B-AD2D-A3932222DABE",
                    SubscriptionLevel = "payingUser",
                    Role = "admin"
                },
                new ApplicationUserProfile
                {
                    Id = Guid.NewGuid(),
                    Subject = "d860efca-22d9-47fd-8249-791ba61b07c7",
                    SubscriptionLevel = "freeUser",
                    Role = "user"
                }
            };
        }
    }
}

