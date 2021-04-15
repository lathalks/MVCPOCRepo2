using System;
using System.Collections.Generic;

#nullable disable

namespace MVCPOC.Models
{
    public partial class Employee
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Title { get; set; }
        public string Division { get; set; }
        public string Building { get; set; }
        public string Room { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
