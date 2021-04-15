using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace MVCPOC.Models
{
    public partial class Applicant
    {
        public Applicant()
        {
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter First Name.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please enter Last Name.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter Business Email.")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Please enter valid email format")]
        public string BusinessEmail { get; set; }
        [Required(ErrorMessage = "Please enter Mobile.")]
        [DataType(DataType.PhoneNumber,ErrorMessage ="Please enter numbers")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string Mobile { get; set; }
        public string CompanyRegNo { get; set; }
        [Required(ErrorMessage = "Please enter Company Name.")]
        public string CompanyName { get; set; }
        public int? TypeId { get; set; }
        public string Username { get; set; }
        [StringLength(10, MinimumLength = 8, ErrorMessage = "Password should be minimum 8 characters.")]
        public string Password { get; set; }

        //[Required(ErrorMessage = "Please agree to Terms of Service")]
        //[Range(typeof(bool), "true", "true", ErrorMessage = "Please agree to Terms of Service")]
        public bool IsTermChecked { get; set; }

        public virtual ApplicantType Type { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
