using Economiq.Server;
using Economiq.Shared.DTO;
using Microsoft.AspNetCore.Mvc;
using Service;
using Service.Models;
using System.Net.Http.Headers;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseController : ControllerBase
    {
        private UserService _userService;
        private ExpenseService _expenseService;
       
        public ExpenseController()
        {
            _expenseService = new ExpenseService();
            _userService = new UserService();
            
        }

        [HttpPost("createExpense")]
        public IActionResult CreateExpense([FromBody] ExpenseDTO expenseDTO)
        {
            if (!_userService.DoesUserExist(TempUser.Username))
            {
                return BadRequest("Invalid Username");
            }

            else if (_userService.IsUserLoggedIn(TempUser.Username, TempUser.Password))
            {
                try
                {
                    _expenseService.AddExpense(expenseDTO, TempUser.Username);
                    return Ok(expenseDTO);
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
        [HttpGet("listExpense")]
        public IActionResult GetExpenses()
        {
            if (!_userService.DoesUserExist(TempUser.Username))
            {
                return BadRequest("Invalid Username");
            }
            else if (_userService.IsUserLoggedIn(TempUser.Username, TempUser.Password))
            {
                try
                {
                    List<GetExpenseDTO> listToReturn = _expenseService.GetAllExpensesByUsername(TempUser.Username);
                   
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
