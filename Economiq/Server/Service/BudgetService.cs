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
            User user = await GetUserByUsername(username);
            if (user.Budgets.Any())
            {
                List<Budget> budgets = user.Budgets.OrderByDescending(b => b.EndDate).ToList();
                List<ListBudgetDTO> budgetsDTO = new List<ListBudgetDTO>();

                foreach(Budget budget in budgets)
                {
                    budgetsDTO.Add(new()
                    {
                        Id = budget.Id,
                        MaxAmount = budget.MaxAmount,
                        YearAndMonth = budget.StartDate.ToString("MMMM yyyy")
                    });
                }
                return budgetsDTO;
            }
            else
            {
                return new List<ListBudgetDTO>();
            }
        }

        public async Task<ListBudgetDTO> GetBudgetById(Guid id, string username)
        {
            User user = await GetUserByUsername(username);
            Budget? budget = user.Budgets.Where(b => b.Id == id).FirstOrDefault();
            if(budget == null)
            {
                throw new Exception("Budget does not exist");
            }
            else
            {
                ListBudgetDTO budgetDTO = new()
                {
                    Id = budget.Id,
                    MaxAmount = budget.MaxAmount,
                    YearAndMonth = budget.StartDate.ToString("MMMM yyyy")
                };
                return budgetDTO;
            }
        }

        public async Task<decimal> GetLatestMaxAmount(string username)
        {
            User user = await GetUserByUsername(username);
            Budget? latestBudget = user.Budgets.OrderByDescending(b => b.EndDate).FirstOrDefault();
            if (latestBudget == null)
            {
                return 0;
            }
            else
            {
                return latestBudget.MaxAmount;
            }
        }

        public async Task<ListBudgetDTO> GetBudgetByDate(CreateBudgetDTO budgetDTO, string username)
        {
            User user = await GetUserByUsername(username);
            if (DateTime.TryParse(budgetDTO.ExpenseDate, out DateTime date))
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
            }
                return null;
        }

        public async Task CreateBudget(CreateBudgetDTO createBudgetDTO, string username)
        {
            User user = await GetUserByUsername(username);

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

        private async Task<User> GetUserByUsername(string username)
        {
            User? user = await _context.Users.Where(u => u.UserName == username).Include(u => u.Budgets).FirstOrDefaultAsync();
            if(user != null)
            {
                return user;
            }
            else
            {
                throw new Exception("User not found");
            }
        }
    }
}
