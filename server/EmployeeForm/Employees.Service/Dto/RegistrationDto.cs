using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Service.Dto
{
    public class RegistrationDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string? AltNumber { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string AppliedPosition { get; set; }
        public string TypeOfWork { get; set; }
        public string? AdditionalNotes { get; set; }
        public IFormFile Photo { get; set; }
        public IFormFile Resume { get; set; }
    }
}
