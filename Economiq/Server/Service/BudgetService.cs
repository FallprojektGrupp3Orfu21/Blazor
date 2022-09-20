using Economiq.Client.Service;
using Economiq.Server.Data;
using Economiq.Shared.DTO;
using Economiq.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Economiq.Server.Service
{
    public class BudgetService
    {
        private BudgetService _budgetService;
        private readonly EconomiqContext _context;

        public BudgetService(EconomiqContext context, BudgetService budgetService)
        {
            _budgetService = budgetService;
            _context = context;
        }

       
    }
}