using Economiq.Server;
using Economiq.Shared.DTO;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Service;
using Service.Models;
using System.Net.Http.Headers;

namespace API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class RecipientController : ControllerBase
    {
        private UserService _userService;
        private RecipientService _recipientService;
        public RecipientController()
        {
            _userService = new UserService();
            _recipientService = new RecipientService();
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
