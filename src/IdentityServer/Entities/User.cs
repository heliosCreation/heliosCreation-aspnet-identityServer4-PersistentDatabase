using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IdentityServer.Entities
{
    public class User : IConcurrencyAware
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(250)]
        public string Subject { get; set; }

        [Required]
        [MaxLength(250)]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(250)]
        public string Email { get; set; }

        [Required]
        [MaxLength(250)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [ConcurrencyCheck]
        public string ConcurrencyStamp { get; set; } = Guid.NewGuid().ToString();

        public ICollection<UserClaim> Claims { get; set; } = new List<UserClaim>();
    }
}
