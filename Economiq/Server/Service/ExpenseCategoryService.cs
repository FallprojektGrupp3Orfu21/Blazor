using Economiq.Server.Data;
using Economiq.Shared.Models;

namespace Service
{
    public class ExpenseCategoryService
    {
        public bool CreateExpenseCategory(string userName, string categoryName)
        {
            using (var context = new EconomiqContext())
            {
                var user = context.Users.Where(user => user.UserName == userName).FirstOrDefault();
                if (user == null)
                {
                    throw new Exception("No User with this Username.");
                }
                var category = context.ExpensesCategory.Where(c => c.CategoryName.ToLower() == categoryName.ToLower()).FirstOrDefault();
                //Goes in here to create the category and add it to the User if the category does not already exist.
                if (category == null)
                {
                    var expenseCategory = new ExpenseCategory { CategoryName = categoryName, CreationDate = DateTime.Now };

                    if (user.ExpensesCategoryNav == null)
                    {
                        var expenseCategoryList = new List<ExpenseCategory> { expenseCategory };
                        user.ExpensesCategoryNav = expenseCategoryList;
                    }
                    else
                    {
                        user.ExpensesCategoryNav.Add(expenseCategory);

                    }
                    try
                    {
                        context.SaveChanges();
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
                    if (user.ExpensesCategoryNav == null)
                    {
                        var expenseCategoryList = new List<ExpenseCategory> { category };
                        user.ExpensesCategoryNav = expenseCategoryList;
                    }
                    else
                    {
                        user.ExpensesCategoryNav.Add(category);
                    }
                    try
                    {
                        context.SaveChanges();
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
}
