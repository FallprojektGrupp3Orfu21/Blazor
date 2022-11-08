using Economiq.Server;
using Economiq.Server.Service;
using Economiq.Shared.DTO;
using Economiq.Shared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class RecipientController : ControllerBase
    {
        private UserService _userService;
        private RecipientService _recipientService;
        public RecipientController(UserService userService, RecipientService recipientService)
        {
            _userService = userService;
            _recipientService = recipientService;
        }
        [Authorize]
        [HttpPost("create")]
        public async Task<IActionResult> CreateRecipient([FromBody] RecipientDTO recipientDTO)
        {

            try
            {
                User? user = _userService.GetCurrentUser(Request.Headers.Authorization);
                if(user == null)
                {
                    throw new Exception();
                }
                await _recipientService.CreateRecipient(user.Id, recipientDTO);
                return Ok("Recipient Created");
            }

            catch (Exception ex)
            {
                return StatusCode(500, "Failed To create Recipient");
            }
        }

        [Authorize]
        [HttpPost("getAll")]
        public async Task<IActionResult> GetRecipients(string? searchString = null)
        {

            try
            {
                User? user = _userService.GetCurrentUser(Request.Headers.Authorization);
                if (user == null)
                {
                    throw new Exception();
                }
                var listToReturn = await _recipientService.GetRecipients(user.Id, searchString);

                return StatusCode(200, listToReturn);
            }

            catch (Exception err)
            {
                return StatusCode(200, "Failed to fetch recipients");
            }


        }
    }
}
