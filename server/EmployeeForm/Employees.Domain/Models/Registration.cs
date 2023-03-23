using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Employees.Domain.Models
{
    public class Registration : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth{ get; set; }
        public string Gender { get; set; }
        public string? AlternateNumber { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string AppliedPosition { get; set; }  
        public string TypeOfWork { get; set; }
        public string? AdditionalNotes { get; set; }
    }
}
