﻿using Economiq.Server.Service;
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

        [HttpGet("listCategories")]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await _categoryService.GetCatergoryById(TempUser.Id);
            return StatusCode(200, categories);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateExpenseCategory([FromBody] ExpenseCategoryDTO expenseCategoryDTO)
        {
            if (!_userService.DoesUserExist(TempUser.Username))
            {
                return BadRequest("Invalid Username");
            }
            else if (_userService.IsUserLoggedIn(TempUser.Username, TempUser.Password))
            {
                try
                {
                    ExpenseCategoryDTO newExpense = await _categoryService.CreateExpenseCategory(TempUser.Id, expenseCategoryDTO.CategoryName);
                    return Created("",newExpense);
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

        [HttpGet("getGraphInfo/{budgetId}")]
        public async Task<IActionResult> GetGraphInfo(Guid budgetId)
        {
            try
            {
                List<CategorySumDTO> categorySum = await _categoryService.GetGraphInfo(TempUser.Id, budgetId);
                return Ok(categorySum);
            }
            catch(ArgumentNullException ex)
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
