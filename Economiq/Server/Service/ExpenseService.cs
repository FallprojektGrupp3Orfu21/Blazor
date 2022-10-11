using Economiq.Server.Data;
using Economiq.Shared.DTO;
using Economiq.Shared.Extensions;
using Economiq.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Economiq.Server.Service
{
    public class ExpenseService
    {
        private ExpenseCategoryService _expenseCategoryService;
        private readonly EconomiqContext _context;
        private readonly BudgetService _budgetService;
        public ExpenseService(EconomiqContext context, ExpenseCategoryService expenseCategoryService, BudgetService budgetService)
        {
            _expenseCategoryService = expenseCategoryService;
            _context = context;
            _budgetService = budgetService;
        }


        public async Task<bool> AddExpense(ExpenseDTO expense, int userId)
        {
            List<Expense> expenses = await _context.Expenses.Where(e => e.UserId == userId).Include(r => r.RecipientId).ToListAsync();
            
            if (expenses == null)
            {
                expenses = new List<Expense>();
            }
            //Length Check for title/comment
            if (expense.Title.Length > 50)
            {
                throw new Exception("Title Too Long (Needs to be less than 50 characters)");
            }
            
            var newExpense = expense.ToExpense(userId);

            CreateBudgetDTO newBudget = new() //Needed to get relevant budget from budget service 
            {
                ExpenseDate = expense.ExpenseDate
            };
            ListBudgetDTO relevantBudget = await _budgetService.GetBudgetByDate(newBudget, TempUser.Id);
            if (relevantBudget == null) //Unhappy Scenario, no budget for time period exists
            {
                var newBudgetMaxAmount = await _budgetService.GetLatestMaxAmount(Economiq.Server.TempUser.Id);
                CreateBudgetDTO createBudgetDTO = new()
                {
                    MaxAmount = newBudgetMaxAmount,
                    ExpenseDate = expense.ExpenseDate
                };
                await _budgetService.CreateBudget(createBudgetDTO, Economiq.Server.TempUser.Id);
            }
            relevantBudget = await _budgetService.GetBudgetByDate(newBudget, Economiq.Server.TempUser.Id);     
            newExpense.BudgetId = relevantBudget.Id;
            
            try
              {
                _context.Expenses.Add(newExpense);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw new Exception("Something went wrong");
            }

        }

        public List<GetExpenseDTO> GetAllExpensesByUsername(string Username)
        {
            List<GetExpenseDTO> listToReturn = new List<GetExpenseDTO>();

                var user = _context.Users.Include(e => e.Expenses).ThenInclude(e=>e.Category).Include(e => e.Recipients).FirstOrDefault(x => x.UserName == Username);
                var expenses = user.Expenses.ToList();


                foreach (var expense in expenses)
                {
                    listToReturn.Add(new GetExpenseDTO { Amount = expense.Amount, Title = expense.Comment, ExpenseDate = expense.ExpenseDate.ToString("dd/MM/yyyy"), categoryName = expense.Category.CategoryName, RecipientName = expense.Recipient.Name }) ;

                }
                return listToReturn;
            
        }

        public async Task<List<GetExpenseDTO>> GetRecentExpenses(string username)
        {
            List<GetExpenseDTO> recentExpenses = new();

            User? user = await _context.Users
                .Include(e => e.Expenses)
                .ThenInclude(e => e.Category)
                .Include(e => e.Recipients)
                .FirstOrDefaultAsync(x => x.UserName == username);
            List<Expense>? expenses = user.Expenses
                .OrderByDescending(x => x.CreationDate)
                .Take(5)
                .ToList();

            if (user.Recipients.Count != 0)
            {
                foreach (var expense in expenses)
                {
                    recentExpenses.Add(new GetExpenseDTO { Amount = expense.Amount, Title = expense.Comment, ExpenseDate = expense.ExpenseDate.ToString("dd/MM/yyyy"), categoryName = expense.Category.CategoryName, RecipientName = expense.Recipient.Name });
                }
                return recentExpenses;
            }
            return new();

        }
    }
}
