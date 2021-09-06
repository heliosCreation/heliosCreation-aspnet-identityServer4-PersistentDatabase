using System;
using System.ComponentModel.DataAnnotations;

namespace Movies.API.Model.Movies
{
    public class MovieUpdateModel
    {
        [Required]
        [MaxLength(120)]
        public string Title { get; set; }

        [Required]
        [MaxLength(120)]
        public string Genre { get; set; }

        [Required]
        [MaxLength(5)]
        public string Rating { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [MaxLength(120)]
        public string ImageUrl { get; set; }
    }
}
