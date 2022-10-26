using Economiq.Server.Service;
using Economiq.Shared.DTO;
using Economiq.Shared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Economiq.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly AuthenticationService _service;
        public AuthenticationController(AuthenticationService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login(Credentials credentials)
        {
            User? currentUser = await _service.Authenticate(credentials);
            if(currentUser == null)
            {
                return Unauthorized();
            }
            string token = _service.GenerateToken(currentUser);
            return Accepted(new { Value = token });
        }
    }
}
