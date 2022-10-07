using Economiq.Shared.DTO;
using Microsoft.AspNetCore.Mvc;
using BudgetService = Economiq.Server.Service.BudgetService;
using UserService = Economiq.Server.Service.UserService;

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


        [HttpGet("listBudgets")]
        public async Task<IActionResult> GetAllBudgets()
        {

            if (!_userService.DoesUserExist(TempUser.Username))
            {
                return BadRequest("Invalid username!");
            }
            else if (_userService.IsUserLoggedIn(TempUser.Username, TempUser.Password))
            {
                try
                {
                    List<ListBudgetDTO> allBudgets = await _budgetService.GetAllBudgets(TempUser.Id);
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


        [HttpGet("getBudgetById/{id}")]
        public async Task<IActionResult> GetBudgetById(Guid id)
        {
            if (_userService.IsUserLoggedIn(TempUser.Username, TempUser.Password))
            {
                try
                {
                    ListBudgetDTO budgetById = await _budgetService.GetBudgetById(id);
                    return StatusCode(200, budgetById);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, ex.Message);
                }
            }
            else
            {
                return BadRequest("User not logged in");
            }
        }


        [HttpGet("getBudgetByDate")]
        public async Task<IActionResult> GetBudgetByDate(CreateBudgetDTO asAS)
        {
            if (_userService.IsUserLoggedIn(TempUser.Username, TempUser.Password))
            {
                try
                {

                    ListBudgetDTO relevantBudget = await _budgetService.GetBudgetByDate(asAS, TempUser.Id);
                    return StatusCode(200, relevantBudget);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, ex.Message);
                }
            }
            else
            {
                return BadRequest("User not logged in");
            }
        }

        [HttpGet("getBudgetByMaxAmount")]
        public async Task<IActionResult> GetBudgetByMaxAmount(int userId)
        {
            if (_userService.IsUserLoggedIn(TempUser.Username, TempUser.Password))
            {
                try
                {
                    ListBudgetDTO budgetByDate = await _budgetService.GetLatestMaxAmount(userId);
                    return StatusCode(200, budgetByDate);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, ex.Message);
                }
            }
            else
            {
                return BadRequest("User not logged in");
            }
        }

        [HttpPost("createBudget")]
        public async Task<IActionResult> CreateBudget([FromBody] CreateBudgetDTO createBudgetDTO)
        {
            if (!_userService.DoesUserExist(TempUser.Username))
            {
                return BadRequest("Invalid Username");
            }
            else if (_userService.IsUserLoggedIn(TempUser.Username, TempUser.Password))
            {
                try
                {
                    await _budgetService.CreateBudget(createBudgetDTO, TempUser.Username);
                    return StatusCode(200, "Budget Successfully Created");
                }

                catch (Exception err)
                {
                    return StatusCode(500, "Failed to create Budget");
                }
            }
            else
            {
                return BadRequest("User not logged in");
            }

        }
    }
}
