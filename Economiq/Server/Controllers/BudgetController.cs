using Economiq.Client.Service;
using Economiq.Server.Service;
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
        private UserService _userService;
        private BudgetService _budgetService;

        public BudgetController(UserService userService, BudgetService budgetService)
        {
            _userService = userService;
            _budgetService = budgetService;
        }


    }
}