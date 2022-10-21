using Economiq.Server.Data;
using Economiq.Shared.DTO;
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


        public async Task<List<ExpenseCategoryDTO>> GetCatergoryById(int UserId)
        {
            var categoriesToReturn = new List<ExpenseCategoryDTO>();
            var user = await _context.Users.Include(e => e.Categories)
                .ThenInclude(e => e.Expenses).FirstOrDefaultAsync(x => x.Id == UserId);
            var categories = user.Categories.ToList();
            foreach (var category in categories)
            {
                categoriesToReturn.Add(new ExpenseCategoryDTO()
                {
                    CategoryName = category.CategoryName,
                    CategoryId = category.Id
                });
            }
            return categoriesToReturn;
        }


        public async Task<bool> CreateExpenseCategory(int userId, string categoryName)
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
                    return true;
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
                    return true;
                }
                catch
                {
                    throw new Exception("Something went wrong");
                }
            }
        }


        public async Task<CategorySumDTO> GetCategorySumById(int userId, int categoryId)
        {
            User? user = await _context.Users
                .Where(u => u.Id == userId)
                .Include(u => u.Categories)
                .ThenInclude(u => u.Expenses.Where(e=>e.UserId == userId))
                .FirstOrDefaultAsync();

            ExpenseCategory? category = user.Categories.Where(u => u.Id == categoryId).FirstOrDefault();
            
            if(category == null)
            {
                throw new ArgumentNullException("Category does not exist");
            }

            decimal totalAmount = 0;
            foreach (Expense expense in category.Expenses)
            {
                totalAmount += expense.Amount;
            }

            CategorySumDTO categorySumDTOs = new()
            {
                CategoryName = category.CategoryName,
                TotalSum = totalAmount
            };

            return categorySumDTOs;
        }
    }
}