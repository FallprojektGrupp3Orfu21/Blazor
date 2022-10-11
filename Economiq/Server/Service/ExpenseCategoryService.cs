using Economiq.Server.Data;
using Economiq.Shared.DTO;
using Economiq.Shared.Models;
using Microsoft.AspNetCore.Mvc;
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
            foreach(var category in categories)
            {
                categoriesToReturn.Add(new ExpenseCategoryDTO()
                {
                    CategoryName = category.CategoryName,
                    CategoryId = category.Id
                });
            }
            return categoriesToReturn;
        }


        public bool CreateExpenseCategory(int userId, string categoryName)
        {
            var user = _context.Users.Where(u => u.Id == userId).Include(u => u.Categories).FirstOrDefault();
            if (user == null)
            {
                throw new Exception("No User with this Username.");
            }
            var category = _context.ExpensesCategory.Where(c => c.CategoryName.ToLower() == categoryName.ToLower()).FirstOrDefault();
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
                    _context.SaveChanges();
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
                    _context.SaveChanges();
                    return true;
                }
                catch
                {
                    throw new Exception("Something went wrong");
                }
            }
        }
    }
}
