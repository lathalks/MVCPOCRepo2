using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCPOC.Models
{
    public class LoginView
    {
        public int Id { get; set; }
        public string Username { get; set; }
        [StringLength(10, MinimumLength = 8, ErrorMessage = "Password should be minimum 8 characters.")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$", ErrorMessage = "Password must be between 8 and 10 characters and contain one uppercase letter, one lowercase letter, one digit and one special character.")]
        public string Password { get; set; }
        [StringLength(10, MinimumLength = 8, ErrorMessage = "Password should be minimum 8 characters.")]
        [Compare("Password",ErrorMessage ="Password and Confirm Password should match")]
        public string ConfirmPassword { get; set; }
    }
}
