using System;
using System.Collections.Generic;

#nullable disable

namespace MVCPOC.Models
{
    public partial class ApplicantType
    {
        public ApplicantType()
        {
            Applicants = new HashSet<Applicant>();
        }

        public int Id { get; set; }
        public string TypeName { get; set; }
        public string TypeDescription { get; set; }

        public virtual ICollection<Applicant> Applicants { get; set; }
    }
}
