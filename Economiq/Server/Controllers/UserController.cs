using Economiq.Server;
using Economiq.Server.Service;
using Economiq.Shared.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser(UserDTO userDTO)
        {
            try
            {
                await _userService.RegisterUser(userDTO);
                return Ok(userDTO);
            }

            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}

