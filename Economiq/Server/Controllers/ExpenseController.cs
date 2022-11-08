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
    public class ExpenseController : ControllerBase
    {
        private UserService _userService;
        private ExpenseService _expenseService;

        public ExpenseController(ExpenseService expenseService, UserService userService)
        {
            _expenseService = expenseService;
            _userService = userService;

        }

        [Authorize]
        [HttpPost("create")]
        public async Task<IActionResult> CreateExpense([FromBody] ExpenseDTO expenseDTO)
        {
            try
            {
                User? user = _userService.GetCurrentUser(Request.Headers.Authorization);
                if (user == null)
                {
                    throw new Exception();
                }
                await _expenseService.AddExpense(expenseDTO, user.Id);
                return StatusCode(200, "Expense Successfully Created");
            }

            catch (Exception err)
            {
                return StatusCode(500, "Failed to create Expense");
            }
        }

        [Authorize]
        [HttpGet("getAll")]
        public async Task<IActionResult> GetExpenses()
        {

            try
            {
                User? user = _userService.GetCurrentUser(Request.Headers.Authorization);
                if (user == null)
                {
                    throw new Exception();
                }
                List<GetExpenseDTO> listToReturn = await _expenseService.GetAllExpensesByUserId(user.Id);
                return StatusCode(200, listToReturn);
            }

            catch (Exception err)
            {
                return StatusCode(500, "Could not fetch Expenses");
            }

        }

        [Authorize]
        [HttpGet("getRecent")]
        public async Task<IActionResult> GetRecentExpenses()
        {

            try
            {
                User? user = _userService.GetCurrentUser(Request.Headers.Authorization);
                if (user == null)
                {
                    throw new Exception();
                }
                List<GetExpenseDTO> recentExpenses = await _expenseService.GetRecentExpenses(user.Id);
                return StatusCode(200, recentExpenses);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Failed to fetch recent Expenses");
            }

        }

        [Authorize]
        [HttpDelete("{DeleteExpenseId}")]
        public async Task<IActionResult> DeleteExpense(int DeleteExpenseId)
        {
            try
            {
                User? user = _userService.GetCurrentUser(Request.Headers.Authorization);
                if (user == null)
                {
                    throw new Exception();
                }
                await _expenseService.DeleteExpenseById(DeleteExpenseId,user.Id);
                return Ok(); 
            }
            catch(Exception ex)
            {
                return BadRequest();
            }
        }
    }
}