using Economiq.Server;
using Economiq.Server.Service;
using Economiq.Shared.DTO;
using Microsoft.AspNetCore.Cors;
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
        [HttpPost("createRecipient")]
        public IActionResult CreateRecipient([FromBody] RecipientDTO recipientDTO)
        {
            if (!_userService.DoesUserExist(TempUser.Username))
            {
                return BadRequest("Invalid Username");
            }
            else if (_userService.IsUserLoggedIn(TempUser.Username, TempUser.Password))
            {
                try
                {
                    _recipientService.CreateRecipient(TempUser.Username, recipientDTO.Name, recipientDTO.City);
                    return Ok(recipientDTO);
                }

                catch (Exception err)
                {
                    return BadRequest(err.Message);
                }
            }
            else
            {
                return BadRequest("User not logged in");
            }

        }
        [EnableCors("corsapp")]
        [HttpPost("listRecipients")]
        public IActionResult GetRecipients(string? searchString=null)
        {
            if (!_userService.DoesUserExist(TempUser.Username))
            {
                return BadRequest("Invalid Username");
            }
            else if (_userService.IsUserLoggedIn(TempUser.Username, TempUser.Password))
            {
                try
                {
                    var listToReturn = _recipientService.GetRecipients(TempUser.Username, searchString);

                    return Ok(listToReturn);
                }

                catch (Exception err)
                {
                    return BadRequest(err.Message);
                }
            }
            else
            {
                return BadRequest("User not logged in");
            }

        }


    }
}
