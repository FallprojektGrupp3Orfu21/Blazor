using Economiq.Server;
using Economiq.Server.Service;
using Economiq.Shared.DTO;
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
        [HttpPost("createExpense")]
        public async Task<IActionResult> CreateExpense([FromBody] ExpenseDTO expenseDTO)
        {
            try
            {
                await _expenseService.AddExpense(expenseDTO, TempUser.Id);
                return StatusCode(200, "Expense Successfully Created");
            }

            catch (Exception err)
            {
                return StatusCode(500, "Failed to create Expense");
            }
        }

        [Authorize]
        [HttpGet("listExpense")]
        public async Task<IActionResult> GetExpenses()
        {

            try
            {
                List<GetExpenseDTO> listToReturn = await _expenseService.GetAllExpensesByUserId(TempUser.Id);
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
                List<GetExpenseDTO> recentExpenses = await _expenseService.GetRecentExpenses(TempUser.Id);
                return StatusCode(200, recentExpenses);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Failed to fetch recent Expenses");
            }

        }

        [HttpDelete("{DeleteExpenseId}")]
        public async Task<IActionResult> DeleteExpense(int DeleteExpenseId)
        {
            try
            {
                await _expenseService.DeleteExpenseById(DeleteExpenseId,TempUser.Id);
                return Ok(); 
            }
            catch(Exception ex)
            {
                return BadRequest();
            }
        }
    }
}