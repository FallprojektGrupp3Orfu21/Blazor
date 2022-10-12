using Economiq.Server.Data;
using Economiq.Shared.DTO;
using Economiq.Shared.Extensions;
using Economiq.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace Economiq.Server.Service
{
    public class BudgetService
    {
        private readonly EconomiqContext _context;
        private readonly CultureInfo _culture;
        public BudgetService(EconomiqContext context)
        {
            _context = context;
            _culture = new CultureInfo("en-GB");
        }

        public async Task<List<ListBudgetDTO>> GetAllBudgets(int userId)
        {
            List<Budget> budgets = await _context.Budgets.Where(b => b.UserId == userId).OrderByDescending(b => b.EndDate).ToListAsync();
            
            if (budgets.Any())
            {
                List<ListBudgetDTO> budgetsDTO = new List<ListBudgetDTO>();

                foreach (Budget budget in budgets)
                {
                    budgetsDTO.Add(budget.ToListBudgetDTO());
                }
                return budgetsDTO;
            }
            else
            {
                return new List<ListBudgetDTO>();
            }
        }

        public async Task<ListBudgetDTO> GetBudgetById(Guid id)
        {
            Budget? budget = await _context.Budgets.Where(b => b.Id == id).FirstOrDefaultAsync();
            List<Expense> expenses = await _context.Expenses.Where(e => e.BudgetId == id).Include(e=>e.Category).Include(e=>e.Recipient).ToListAsync();

            if (budget == null)
            {
                throw new Exception("Budget does not exist");
            }
            else
            {
                List<GetExpenseDTO> expenseDTOs = new List<GetExpenseDTO>();
                foreach (var expense in expenses)
                {
                    expenseDTOs.Add(expense.ToGetExpenseDTO());
                }

                ListBudgetDTO budgetDTO = budget.ToListBudgetDTO();
                budgetDTO.Expenses = expenseDTOs;
                return budgetDTO;
            }
        }

        public async Task<decimal> GetLatestMaxAmount(int userId)
        {
            Budget? latestBudget = await _context.Budgets.Where(b => b.UserId == userId).OrderByDescending(b => b.EndDate).FirstOrDefaultAsync();
            if (latestBudget == null)
            {
                return 0;
            }
            else
            {
                return latestBudget.MaxAmount;
            }
        }

        public async Task<ListBudgetDTO> GetBudgetByDate(CreateBudgetDTO budgetDTO, int userId)
        {
            if (DateTime.TryParse(budgetDTO.ExpenseDate, out DateTime date))
            {
                Budget? budget = await _context.Budgets.Where(b => b.UserId == userId && b.StartDate <= date && date <= b.EndDate).FirstOrDefaultAsync();
                
                if (budget != null)
                {
                    ListBudgetDTO newBudgetDTO = budget.ToListBudgetDTO();
                    return newBudgetDTO;
                }
            }
            return null;
        }

        public async Task CreateBudget(CreateBudgetDTO createBudgetDTO, int userId)
        {
            if (DateTime.TryParse(createBudgetDTO.ExpenseDate, out DateTime date))
            {
                DateTime firstDayOfMonth = new DateTime(date.Year, date.Month, 1);
                DateTime lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);
                Budget newBudget = new()
                {
                    Id = Guid.NewGuid(),
                    StartDate = firstDayOfMonth,
                    EndDate = lastDayOfMonth,
                    MaxAmount = createBudgetDTO.MaxAmount,
                    Expenses = new List<Expense>(),
                    UserId = userId
                };
                _context.Budgets.Add(newBudget);

                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Could not parse expense date");
            }
        }
     
    }
}


