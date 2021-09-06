using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.API.Model.Movies
{
    public class MovieCreationModel
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
