using Economiq.Server.Data;
using Economiq.Shared.DTO;
using Economiq.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Economiq.Server.Service
{
    public class BudgetService
    {
        private readonly EconomiqContext _context;
        public BudgetService(EconomiqContext context)
        {
            _context = context;
        }

        public async Task<List<ListBudgetDTO>> GetAllBudgets(string username)
        {
            return new();
        }

        public async Task<List<ListBudgetDTO>> GetBudgetById(Guid id, string username)
        {
            return new();
        }

        public async Task<decimal> GetLatestMaxAmount(string username)
        {
            //Return latest maxAmount or 0
            return 0;
        }

        public async Task<ListBudgetDTO> GetBudgetByDate(CreateBudgetDTO budgetDTO, string username)
        {
            var user = _context.Users.Where(u => u.UserName == username).Include(u => u.Budgets).FirstOrDefault();
            if(DateTime.TryParse(budgetDTO.ExpenseDate, out DateTime date))
            {
                Budget? budget = user.Budgets.Where(b => b.StartDate <= date && date <= b.EndDate).FirstOrDefault();
                if(budget != null)
                {
                    ListBudgetDTO newBudgetDTO = new()
                    {
                        Id = budget.Id,
                        MaxAmount = budget.MaxAmount,
                        YearAndMonth = budget.StartDate.ToString("MMMM yyyy")
                    };
                    return newBudgetDTO;
                }
                else
                {
                   return null;
                }
            }
            

            return new();
        }

        public async Task CreateBudget(CreateBudgetDTO createBudgetDTO, string username)
        {
            var user = _context.Users.Where(u => u.UserName == username).FirstOrDefault();

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
                    UserNav = user.Id
                };
                user.Budgets.Add(newBudget);
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    //How Do i properly rethrow exception with perserved stack trace?
                    throw ex;
                }
            }
            else
            {
                throw new Exception("Could not parse expense date");
            }
        }
    }
}
