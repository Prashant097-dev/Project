using System;
using System.Collections.Generic;

#nullable disable

namespace ProjectWebAppDBFirst.Models
{
    public partial class Admin
    {
        public int AdminId { get; set; }
        public string AdminPassword { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string ContactNumber { get; set; }
    }
}
