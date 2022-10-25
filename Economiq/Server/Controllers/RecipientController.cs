using Economiq.Server;
using Economiq.Server.Service;
using Economiq.Shared.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    [Route("api/")]
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
        [HttpPost("createRecipient")]
        public async Task<IActionResult> CreateRecipient([FromBody] RecipientDTO recipientDTO)
        {

            try
            {
                await _recipientService.CreateRecipient(TempUser.Id, recipientDTO);
                return Ok("Recipient Created");
            }

            catch (Exception ex)
            {
                return StatusCode(500, "Failed To create Recipient");
            }
        }

        [Authorize]
        [HttpPost("listRecipients")]
        public async Task<IActionResult> GetRecipients(string? searchString = null)
        {

            try
            {
                var listToReturn = await _recipientService.GetRecipients(TempUser.Id, searchString);

                return StatusCode(200, listToReturn);
            }

            catch (Exception err)
            {
                return StatusCode(200, "Failed to fetch recipients");
            }


        }
    }
}
