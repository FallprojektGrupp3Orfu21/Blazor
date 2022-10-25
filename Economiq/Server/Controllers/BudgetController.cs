using Economiq.Server.Service;
using Economiq.Shared.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

//Economiq.Server.Service.UserService;

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
        [HttpGet("listBudgets")]
        public async Task<IActionResult> GetAllBudgets()
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

        [Authorize]
        [HttpGet("getBudgetById/{id}")]
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
        [HttpPost("getBudgetByDate")]
        public async Task<IActionResult> GetBudgetByDate(CreateBudgetDTO dto)
        {

            try
            {
                var relevantBudget = await _budgetService.GetBudgetByDate(dto, TempUser.Id);
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
                decimal latestMaxAmount = await _budgetService.GetLatestMaxAmount(TempUser.Id);

                return StatusCode(200, latestMaxAmount);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [Authorize]
        [HttpPost("createBudget")]
        public async Task<IActionResult> CreateBudget([FromBody] CreateBudgetDTO createBudgetDTO)
        {

            try
            {
                Guid createdBudgetId = await _budgetService.CreateBudget(createBudgetDTO, TempUser.Id);
                return StatusCode(200, createdBudgetId);
            }

            catch (Exception err)
            {
                return StatusCode(500, "Failed to create Budget");
            }


        }

    }

}
