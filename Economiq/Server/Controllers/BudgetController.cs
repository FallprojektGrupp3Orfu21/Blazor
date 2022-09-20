using Economiq.Server;
using Economiq.Server.Service;
using Economiq.Shared.DTO;
using Microsoft.AspNetCore.Mvc;


namespace Economiq.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BudgetController : ControllerBase
    {

        private BudgetService _budgetService;
        private UserService _userService;

        public BudgetController(BudgetService budgetService, UserService userService)
        {
            _budgetService = budgetService;
            _userService = userService;
        }


        [HttpGet("ListBudgets")]
        public async Task<IActionResult> GetAllBudgets(UserService userService)
        {

            if (!_userService.DoesUserExist(TempUser.Username))
            {
                return BadRequest("Invalid username!");
            }
            else if (_userService.IsUserLoggedIn(TempUser.Username, TempUser.Password))
            {
                try
                {
                    List<ListBudgetDTO> allBudgets = await _budgetService.GetAllBudgets(TempUser.Username);
                    return StatusCode(200, allBudgets);
                }

                catch (Exception err)
                {
                    return StatusCode(500, "Could not fetch budgets");
                }
            }
            else
            {
                return BadRequest("User not logged in");
            }

        }


        [HttpGet("GetBudgetById")]
        public async Task<IActionResult> GetBudgetById(ListBudgetDTO listBudgetDTO, UserService userService)
        {
            if (_userService.IsUserLoggedIn(TempUser.Username, TempUser.Password))
            {
                try
                {
                    var budgetById = await _budgetService.GetBudgetById(listBudgetDTO.Id, TempUser.Username);
                    return StatusCode(200, budgetById);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, "Failed to fetch budget");
                }
            }
            else
            {
                return BadRequest("User not logged in");
            }


        }
    }
}
