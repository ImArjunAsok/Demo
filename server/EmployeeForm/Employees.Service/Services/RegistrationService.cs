using Employees.Domain.Models;
using Employees.Service.Data;
using Employees.Service.Dto;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;

namespace Employees.Service.Services
{
    public class RegistrationService
    {
        private readonly UserManager<Registration> _userManager;
        private readonly SignInManager<Registration> _signInManager;
        private readonly ApplicationDbContext _db;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _env;

        public RegistrationService(UserManager<Registration> userManager,
                                   SignInManager<Registration> signInManager,
                                   ApplicationDbContext db,
                                   Microsoft.AspNetCore.Hosting.IHostingEnvironment env
                                   )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _db = db;
            _env = env;
        }

        public async Task<bool> RegisterUserAsync(RegistrationDto dto)
        {
            var pathPhoto = "";
            var pathResume = "";
            if (dto.Photo != null && dto.Photo.Length > 0)
            {
                var uploadsFolder = Path.Combine(_env.ContentRootPath, "C:\\Users\\arjun.asok\\Documents\\PhotoServer");
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(dto.Photo.FileName);
                pathPhoto = Path.Combine(uploadsFolder, fileName);
                using (var stream = new FileStream(pathPhoto, FileMode.Create))
                {
                    await dto.Photo.CopyToAsync(stream);
                }
            }

            if (dto.Resume != null && dto.Resume.Length > 0)
            {
                var uploadsFolder = Path.Combine(_env.ContentRootPath, "C:\\Users\\arjun.asok\\Documents\\PhotoServer");
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(dto.Resume.FileName);
                pathResume = Path.Combine(uploadsFolder, fileName);
                using (var stream = new FileStream(pathResume, FileMode.Create))
                {
                    await dto.Resume.CopyToAsync(stream);
                }
            }
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
                AdditionalNotes = dto.AdditionalNotes,
                PhotoPath = pathPhoto,
                ResumePath = pathResume,
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
