using Economiq.Server.Data;
using Economiq.Shared.DTO;
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

            var addExpense = _context.Expenses.Where(addExpense => addExpense.UserId == userId).Include(r => r.RecipientId).FirstOrDefault();
            var recipient = _context.Recipients.Where(rec => rec.Id == expense.RecipientId).FirstOrDefault();
            
            
                
            
            //Gets the category the expense belongs to, or creates one if it doesnt exist.
            var category = _context.ExpensesCategory.Where(c => c.CategoryName.ToLower() == expense.CategoryName.ToLower()).FirstOrDefault();
            if (category == null)
            {
                try
                {
                    _expenseCategoryService.CreateExpenseCategory(user, expense.CategoryName);
                    category = _context.ExpensesCategory.Where(c => c.CategoryName.ToLower() == expense.CategoryName.ToLower()).FirstOrDefault();
                }
                catch
                {
                    throw new Exception("Could not create missing Category");
                }
            }
            //Length Check for title/comment
            if (expense.Title.Length > 50)
            {
                throw new Exception("Title Too Long (Needs to be less than 50 characters)");
            }
            //Creates the expense and adds it to the user (creates list ifs the first expense on the user)
            DateTime expenseDate = DateTime.Parse(expense.ExpenseDate).Date;
            DateTime creationDate = DateTime.Now;
            var newExpense = new Expense { Amount = expense.Amount, CreationDate = creationDate, ExpenseDate = expenseDate, Comment = expense.Title, UserId = user.Id, CategoryId = category.Id, RecipientId = recipient.Id };

            if (user.Expenses == null)
            {
                user.Expenses = new List<Expense>();
            }
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
                user.Expenses.Add(newExpense);
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

            if(user.Recipients.Count != 0){ 
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
