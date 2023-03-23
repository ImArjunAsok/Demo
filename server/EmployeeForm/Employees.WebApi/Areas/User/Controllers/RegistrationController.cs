using Employees.Service.Dto;
using Employees.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;

namespace Employees.WebApi.Areas.User.Controllers
{
    public class RegistrationController : BaseController
    {
        private readonly RegistrationService _registrationService;

        public RegistrationController(RegistrationService registrationService)
        {
            _registrationService = registrationService;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser(RegistrationDto dto)
        {
            var res = await _registrationService.RegisterUserAsync(dto);
            return Ok(res);
        }
    }
}
