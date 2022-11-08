using Economiq.Server.Service;
using Economiq.Shared.DTO;
using Economiq.Shared.Models;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize]
        [HttpGet("getAll")]
        public async Task<IActionResult> GetAllBudgets()
        {
            try
            {
                User? user = _userService.GetCurrentUser(Request.Headers.Authorization);
                if (user == null)
                {
                    throw new Exception();
                }
                List<ListBudgetDTO> allBudgets = await _budgetService.GetAllBudgets(user.Id);
                return StatusCode(200, allBudgets);
            }
            catch (Exception err)
            {
                return StatusCode(500, "Could not fetch budgets");
            }
        }

        [Authorize]
        [HttpGet("getById/{id}")]
        public async Task<IActionResult> GetBudgetById(Guid id)
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

        [Authorize]
        [HttpPost("getByDate")]
        public async Task<IActionResult> GetBudgetByDate(CreateBudgetDTO dto)
        {
            try
            {
                User? user = _userService.GetCurrentUser(Request.Headers.Authorization);
                if (user == null)
                {
                    throw new Exception();
                }
                var relevantBudget = await _budgetService.GetBudgetByDate(dto, user.Id);
                return StatusCode(200, relevantBudget);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [Authorize]
        [HttpGet("getLatestMaxAmount")]
        public async Task<IActionResult> GetLatestMaxAmount()
        {
            try
            {
                User? user = _userService.GetCurrentUser(Request.Headers.Authorization);
                if (user == null)
                {
                    throw new Exception();
                }
                decimal latestMaxAmount = await _budgetService.GetLatestMaxAmount(user.Id);

                return StatusCode(200, latestMaxAmount);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [Authorize]
        [HttpPost("create")]
        public async Task<IActionResult> CreateBudget([FromBody] CreateBudgetDTO createBudgetDTO)
        {
            try
            {
                User? user = _userService.GetCurrentUser(Request.Headers.Authorization);
                if (user == null)
                {
                    throw new Exception();
                }
                Guid createdBudgetId = await _budgetService.CreateBudget(createBudgetDTO, user.Id);
                return StatusCode(200, createdBudgetId);
            }

            catch (Exception err)
            {
                return StatusCode(500, "Failed to create Budget");
            }


        }

    }

}
