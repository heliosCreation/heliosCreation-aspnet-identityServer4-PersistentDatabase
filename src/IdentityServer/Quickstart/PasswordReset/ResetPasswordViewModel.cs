using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Quickstart.PasswordReset
{
    public class ResetPasswordViewModel
    {
        public string SecurityCode { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MaxLength(250)]
        public string Password { get; set; }
        
        [Required]
        [Compare("Password")]
        [DataType(DataType.Password)]
        [MaxLength(250)]
        [Display(Name = "Confirm your password")]
        public string PasswordConfirmation { get; set; }
    }
}
