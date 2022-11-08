using Economiq.Server.Service;
using Economiq.Shared.DTO;
using Economiq.Shared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Economiq.Server.Controllers
{
    [Route("api/category")]
    [ApiController]
    public class ExpenseCategoryController : ControllerBase
    {
        private UserService _userService;
        private ExpenseCategoryService _categoryService;
        public ExpenseCategoryController(UserService userService, ExpenseCategoryService categoryService)
        {
            _userService = userService;
            _categoryService = categoryService;
        }

        [Authorize]
        [HttpGet("getAll")]
        public async Task<IActionResult> GetCategories()
        {
            try
            {
                User? user = _userService.GetCurrentUser(Request.Headers.Authorization);
                if (user == null)
                {
                    throw new Exception();
                }
                var categories = await _categoryService.GetCategories(user.Id);
                return StatusCode(200, categories);
            }
            catch
            {
                return StatusCode(500, "Could not fetch categories");
            }
        }


        [Authorize]
        [HttpPost("create")]
        public async Task<IActionResult> CreateExpenseCategory([FromBody] ExpenseCategoryDTO expenseCategoryDTO)
        {

            try
            {
                User? user = _userService.GetCurrentUser(Request.Headers.Authorization);
                if (user == null)
                {
                    throw new Exception();
                }
                ExpenseCategoryDTO newExpense = await _categoryService.CreateExpenseCategory(user.Id, expenseCategoryDTO.CategoryName);
                return Created("", newExpense);
            }

            catch (Exception err)
            {
                return StatusCode(500, "Failed to create Category");
            }
        }

        [Authorize]
        [HttpGet("getGraphInfo/{budgetId}")]
        public async Task<IActionResult> GetGraphInfo(Guid budgetId)
        {
            try
            {
                User? user = _userService.GetCurrentUser(Request.Headers.Authorization);
                if (user == null)
                {
                    throw new Exception();
                }
                List<CategorySumDTO> categorySum = await _categoryService.GetGraphInfo(user.Id, budgetId);
                return Ok(categorySum);
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex.Message);
            }
            catch
            {
                return StatusCode(500, "Failed to fetch categorySum");
            }
        }
    }
}
