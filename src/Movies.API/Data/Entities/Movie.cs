using System;

namespace Movies.API.Data.Entities
{
    public class Movie : AuditableEntity
    {
        public string Title { get; set; }

        public string Genre { get; set; }

        public string Rating { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string ImageUrl { get; set; }

        public string OwnerId { get; set; }
    }
}
