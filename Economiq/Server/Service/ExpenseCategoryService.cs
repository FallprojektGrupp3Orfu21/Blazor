using Economiq.Server.Data;
using Economiq.Shared.DTO;
using Economiq.Shared.Extensions;
using Economiq.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Economiq.Server.Service
{
    public class ExpenseCategoryService
    {
        private readonly EconomiqContext _context;

        public ExpenseCategoryService(EconomiqContext context)
        {
            _context = context;
        }


        public async Task<List<ExpenseCategoryDTO>> GetCategories(int UserId)
        {
            var categoriesToReturn = new List<ExpenseCategoryDTO>();

            var user = await _context.Users.Include(e => e.Categories)
                .ThenInclude(e => e.Expenses.Where(e => e.UserId == UserId))
                .ThenInclude(e => e.Recipient)
                .FirstOrDefaultAsync(x => x.Id == UserId);
            var categories = user.Categories.ToList();

            foreach (var category in categories)
            {
                List<GetExpenseDTO> expensesToReturn = new();
                foreach (var expense in category.Expenses)
                {
                    expensesToReturn.Add(expense.ToGetExpenseDTO());
                }
               
                categoriesToReturn.Add(new ExpenseCategoryDTO()
                {
                    CategoryName = category.CategoryName,
                    CategoryId = category.Id,
                    Expenses = expensesToReturn
                    
                    
                });
            }
            return categoriesToReturn;
        }


        public async Task<ExpenseCategoryDTO> CreateExpenseCategory(int userId, string categoryName)
        {
            var user = await _context.Users.Where(u => u.Id == userId).Include(u => u.Categories).FirstOrDefaultAsync();
            if (user == null)
            {
                throw new Exception("No User with this Username.");
            }
            var category = await _context.ExpensesCategory.Where(c => c.CategoryName.ToLower() == categoryName.ToLower()).FirstOrDefaultAsync();
            //Goes in here to create the category and add it to the User if the category does not already exist.
            if (category == null)
            {
                var expenseCategory = new ExpenseCategory { CategoryName = categoryName, CreationDate = DateTime.Now };

                if (user.Categories == null)
                {
                    var expenseCategoryList = new List<ExpenseCategory> { expenseCategory };
                    user.Categories = expenseCategoryList;
                }
                else
                {
                    user.Categories.Add(expenseCategory);

                }
                try
                {
                    await _context.SaveChangesAsync();
                    return new ExpenseCategoryDTO() { CategoryId = expenseCategory.Id, CategoryName=expenseCategory.CategoryName};
                }
                catch
                {
                    throw new Exception("Something went wrong");
                }
            }
            //Goes in here and adds Category to the User, if there already exists a category with the same name.
            else
            {
                if (user.Categories == null)
                {
                    var expenseCategoryList = new List<ExpenseCategory> { category };
                    user.Categories = expenseCategoryList;
                }
                else
                {
                    user.Categories.Add(category);
                }
                try
                {
                    await _context.SaveChangesAsync();
                    return new ExpenseCategoryDTO() { CategoryId=category.Id, CategoryName=category.CategoryName};
                }
                catch
                {
                    throw new Exception("Something went wrong");
                }
            }
        }


        public async Task<List<CategorySumDTO>> GetGraphInfo(int userId, Guid budgetId)
        {
            User? user = await _context.Users
                .Where(u => u.Id == userId)
                .Include(u => u.Categories)
                .ThenInclude(u => u.Expenses.Where(e=>e.UserId == userId && e.BudgetId == budgetId))
                .FirstOrDefaultAsync();

            List<ExpenseCategory> categories = user.Categories.ToList();
            List<CategorySumDTO> sumDTOs = new();
            
            foreach(ExpenseCategory category in categories)
            {
                if (category == null)
                {
                    throw new ArgumentNullException("Category does not exist");
                }

                decimal totalAmount = 0;
                foreach (Expense expense in category.Expenses)
                {
                    totalAmount += expense.Amount;
                }

                CategorySumDTO categorySumDTO = new()
                {
                    CategoryName = category.CategoryName,
                    TotalSum = totalAmount,
                    CategoryId = category.Id
                };
                sumDTOs.Add(categorySumDTO);
            }
            return sumDTOs;
        }
    }
}
