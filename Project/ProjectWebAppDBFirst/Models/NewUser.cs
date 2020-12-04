using System;
using System.Collections.Generic;

#nullable disable

namespace ProjectWebAppDBFirst.Models
{
    public partial class NewUser
    {
        public int UserId { get; set; }
        public string UserPassword { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public double? UserPin { get; set; }
        public string UserLocation { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string ContactNumber { get; set; }
    }
}
