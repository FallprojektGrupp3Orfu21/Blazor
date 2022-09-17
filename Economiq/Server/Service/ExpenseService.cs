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

        public ExpenseService(EconomiqContext context, ExpenseCategoryService expenseCategoryService)
        {
            _expenseCategoryService = expenseCategoryService;
            _context = context;
        }

        public bool AddExpense(ExpenseDTO expense, string userName)
        {
            //Gest the user by username
            var user = _context.Users.Where(user => user.UserName == userName).Include(r => r.RecipientNav).FirstOrDefault();
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8604 // Possible null reference argument for parameter 'source' in 'IEnumerable<Recipient> Enumerable.Where<Recipient>(IEnumerable<Recipient> source, Func<Recipient, bool> predicate)'.
            var recipient = user.RecipientNav.Where(rec => rec.Name == expense.RecipientName).FirstOrDefault();
#pragma warning restore CS8604 // Possible null reference argument for parameter 'source' in 'IEnumerable<Recipient> Enumerable.Where<Recipient>(IEnumerable<Recipient> source, Func<Recipient, bool> predicate)'.
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            if (user == null)
            {
                throw new Exception("No User with this Username.");
            }
            //Gets the category the expense belongs to, or creates one if it doesnt exist.
            var category = _context.ExpensesCategory.Where(c => c.CategoryName.ToLower() == expense.CategoryName.ToLower()).FirstOrDefault();
            if (category == null)
            {
                try
                {
                    _expenseCategoryService.CreateExpenseCategory(userName, expense.CategoryName);
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
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            var newExpense = new Expense { Amount = expense.Amount, CreationDate = creationDate, ExpenseDate = expenseDate, Comment = expense.Title, UserNavId = user.Id, CategoryNavId = category.Id, RecipientNavId = recipient.Id };
#pragma warning restore CS8602 // Dereference of a possibly null reference.
#pragma warning restore CS8602 // Dereference of a possibly null reference.

            if (user.UserExpensesNav == null)
            {
                user.UserExpensesNav = new List<Expense> { newExpense };
            }
            else
            {
                user.UserExpensesNav.Add(newExpense);
            }
            try
            {
                _context.SaveChanges();
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

#pragma warning disable CS8620 // Argument of type 'IIncludableQueryable<User, List<Expense>?>' cannot be used for parameter 'source' of type 'IIncludableQueryable<User, IEnumerable<Expense>>' in 'IIncludableQueryable<User, ExpenseCategory?> EntityFrameworkQueryableExtensions.ThenInclude<User, Expense, ExpenseCategory?>(IIncludableQueryable<User, IEnumerable<Expense>> source, Expression<Func<Expense, ExpenseCategory?>> navigationPropertyPath)' due to differences in the nullability of reference types.
            var user = _context.Users.Include(e => e.UserExpensesNav).ThenInclude(e => e.CategoryNav).Include(e => e.RecipientNav).FirstOrDefault(x => x.UserName == Username);
#pragma warning restore CS8620 // Argument of type 'IIncludableQueryable<User, List<Expense>?>' cannot be used for parameter 'source' of type 'IIncludableQueryable<User, IEnumerable<Expense>>' in 'IIncludableQueryable<User, ExpenseCategory?> EntityFrameworkQueryableExtensions.ThenInclude<User, Expense, ExpenseCategory?>(IIncludableQueryable<User, IEnumerable<Expense>> source, Expression<Func<Expense, ExpenseCategory?>> navigationPropertyPath)' due to differences in the nullability of reference types.
#pragma warning disable CS8604 // Possible null reference argument for parameter 'source' in 'List<Expense> Enumerable.ToList<Expense>(IEnumerable<Expense> source)'.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            var expenses = user.UserExpensesNav.ToList();
#pragma warning restore CS8602 // Dereference of a possibly null reference.
#pragma warning restore CS8604 // Possible null reference argument for parameter 'source' in 'List<Expense> Enumerable.ToList<Expense>(IEnumerable<Expense> source)'.

            foreach (var expense in expenses)
            {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                listToReturn.Add(new GetExpenseDTO { Amount = expense.Amount, Title = expense.Comment, ExpenseDate = expense.ExpenseDate.ToString("dd/MM/yyyy"), categoryName = expense.CategoryNav.CategoryName, RecipientName = expense.RecipientNav.Name });
#pragma warning restore CS8602 // Dereference of a possibly null reference.
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            }
            return listToReturn;
        }

        public async Task<List<GetExpenseDTO>> GetRecentExpenses(string username)
        {
            List<GetExpenseDTO> recentExpenses = new();

#pragma warning disable CS8620 // Argument of type 'IIncludableQueryable<User, List<Expense>?>' cannot be used for parameter 'source' of type 'IIncludableQueryable<User, IEnumerable<Expense>>' in 'IIncludableQueryable<User, ExpenseCategory?> EntityFrameworkQueryableExtensions.ThenInclude<User, Expense, ExpenseCategory?>(IIncludableQueryable<User, IEnumerable<Expense>> source, Expression<Func<Expense, ExpenseCategory?>> navigationPropertyPath)' due to differences in the nullability of reference types.
            User? user = await _context.Users
                .Include(e => e.UserExpensesNav)
                .ThenInclude(e => e.CategoryNav)
                .Include(e => e.RecipientNav)
                .FirstOrDefaultAsync(x => x.UserName == username);
#pragma warning restore CS8620 // Argument of type 'IIncludableQueryable<User, List<Expense>?>' cannot be used for parameter 'source' of type 'IIncludableQueryable<User, IEnumerable<Expense>>' in 'IIncludableQueryable<User, ExpenseCategory?> EntityFrameworkQueryableExtensions.ThenInclude<User, Expense, ExpenseCategory?>(IIncludableQueryable<User, IEnumerable<Expense>> source, Expression<Func<Expense, ExpenseCategory?>> navigationPropertyPath)' due to differences in the nullability of reference types.

#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8604 // Possible null reference argument for parameter 'source' in 'IOrderedEnumerable<Expense> Enumerable.OrderByDescending<Expense, DateTime>(IEnumerable<Expense> source, Func<Expense, DateTime> keySelector)'.
            List<Expense> expenses = user.UserExpensesNav
                .OrderByDescending(x => x.CreationDate)
                .Take(5)
                .ToList();
#pragma warning restore CS8604 // Possible null reference argument for parameter 'source' in 'IOrderedEnumerable<Expense> Enumerable.OrderByDescending<Expense, DateTime>(IEnumerable<Expense> source, Func<Expense, DateTime> keySelector)'.
#pragma warning restore CS8602 // Dereference of a possibly null reference.

            foreach (var expense in expenses)
            {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                recentExpenses.Add(new GetExpenseDTO { Amount = expense.Amount, Title = expense.Comment, ExpenseDate = expense.ExpenseDate.ToString("dd/MM/yyyy"), categoryName = expense.CategoryNav.CategoryName, RecipientName = expense.RecipientNav.Name });
#pragma warning restore CS8602 // Dereference of a possibly null reference.
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            }
            return recentExpenses;
        }
    }
}