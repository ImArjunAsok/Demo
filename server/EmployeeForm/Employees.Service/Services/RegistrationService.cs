using Employees.Domain.Models;
using Employees.Service.Data;
using Employees.Service.Dto;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Service.Services
{
    public class RegistrationService
    {
        private readonly UserManager<Registration> _userManager;
        private readonly SignInManager<Registration> _signInManager;
        private readonly ApplicationDbContext _db;

        public RegistrationService(UserManager<Registration> userManager,
                                   SignInManager<Registration> signInManager,
                                   ApplicationDbContext db)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _db = db;
        }

        public async Task<bool> RegisterUserAsync(RegistrationDto dto)
        {
            var user = new Registration()
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                DateOfBirth = dto.DateOfBirth,
                UserName = dto.Email,
                Gender = dto.Gender,
                PhoneNumber = dto.PhoneNumber,
                AlternateNumber = dto.AltNumber,
                Address = dto.Address,
                Country = dto.Country,
                State = dto.State,
                City = dto.City,
                AppliedPosition = dto.AppliedPosition,
                TypeOfWork = dto.TypeOfWork,
                AdditionalNotes = dto.AdditionalNotes
            };
            var userStatus = await _userManager.CreateAsync(user, dto.Password);
            if(!userStatus.Succeeded)
            {
                return false;
            }
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
