using System;
using System.ComponentModel.DataAnnotations;

namespace Movies.API.Data.Entities
{
    public class ApplicationUserProfile
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Subject { get; set; }

        [Required]
        [MaxLength(250)]
        public string SubscriptionLevel { get; set; }

        [Required]
        [MaxLength(250)]
        public string Role { get; set; }
    }
}
