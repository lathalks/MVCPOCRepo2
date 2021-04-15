using System;
using System.Collections.Generic;

#nullable disable

namespace MVCPOC.Models
{
    public partial class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int? ApplicantId { get; set; }

        public virtual Applicant Applicant { get; set; }
    }
}
