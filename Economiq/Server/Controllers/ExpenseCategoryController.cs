using Economiq.Server.Service;
using Economiq.Shared.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Economiq.Server.Controllers
{
    [Route("api/[controller]")]
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

        [HttpPost("create")]
        public IActionResult CreateExpenseCategory([FromBody] ExpenseCategoryDTO expenseCategoryDTO)
        {
            if (!_userService.DoesUserExist(TempUser.Username))
            {
                return BadRequest("Invalid Username");
            }
            else if (_userService.IsUserLoggedIn(TempUser.Username, TempUser.Password))
            {
                try
                {
                    _categoryService.CreateExpenseCategory(TempUser.Username, expenseCategoryDTO.CategoryName);
                    return StatusCode(200, "Category Successfully Created");
                }
                catch (Exception err)
                {
                    return StatusCode(500, "Failed to create Category");
                }
            }
            else
            {
                return BadRequest("User not logged in");
            }
        }
    }
}