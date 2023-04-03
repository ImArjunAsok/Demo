using Employees.Service.Dto;
using Employees.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using org.apache.pdfbox.pdmodel;
using org.apache.pdfbox.util;

namespace Employees.WebApi.Areas.User.Controllers
{
    public class RegistrationController : BaseController
    {
        private readonly RegistrationService _registrationService;
        private readonly IWebHostEnvironment _env;
        private readonly ApplicationDbContext _db;

        public RegistrationController(RegistrationService registrationService,
                                      IWebHostEnvironment env,
                                      ApplicationDbContext db)
        {
            _registrationService = registrationService;
            _env = env;
            _db = db;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser([FromForm] RegistrationDto dto)
        {
            var res = await _registrationService.RegisterUserAsync(dto);
            return Ok(res);
        }

        [HttpPost("upload")]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("No file uploaded.");

            using (var stream = new MemoryStream())
            {
                await file.CopyToAsync(stream);
                var buffer = stream.ToArray();
                var text = _registrationService.ExtractTextFromPdf(buffer);
                return Ok(text);
            }
        }

    }
}
