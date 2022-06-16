using Economiq.Shared.DTO;
using Microsoft.AspNetCore.Mvc;
using Service;
using Service.Models;
using System.Net.Http.Headers;

namespace Economiq.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseCategoryController : ControllerBase
    {
        private UserService _userService;
        private ExpenseCategoryService _categoryService;
        public ExpenseCategoryController()
        {
            _userService = new UserService();
            _categoryService = new ExpenseCategoryService();
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
                    return Ok(expenseCategoryDTO);
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
