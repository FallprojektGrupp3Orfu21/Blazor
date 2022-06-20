﻿using Economiq.Server.Data;
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
            using (var context = new EconomiqContext())
            {
                //Gest the user by username
                var user = context.Users.Where(user => user.UserName == userName).Include(r => r.RecipientNav).FirstOrDefault();
                var recipient = user.RecipientNav.Where(rec => rec.Name == expense.RecipientName).FirstOrDefault();
                if (user == null)
                {
                    throw new Exception("No User with this Username.");
                }
                //Gets the category the expense belongs to, or creates one if it doesnt exist.
                var category = context.ExpensesCategory.Where(c => c.CategoryName.ToLower() == expense.CategoryName.ToLower()).FirstOrDefault();
                if (category == null)
                {
                    try
                    {
                        _expenseCategoryService.CreateExpenseCategory(userName, expense.CategoryName);
                        category = context.ExpensesCategory.Where(c => c.CategoryName.ToLower() == expense.CategoryName.ToLower()).FirstOrDefault();
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
                var newExpense = new Expense { Amount = expense.Amount, CreationDate = creationDate, ExpenseDate = expenseDate, Comment = expense.Title, UserNavId = user.Id, CategoryNavId = category.Id, RecipientNavId = recipient.Id };

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
                    context.SaveChanges();
                    return true;
                }
                catch
                {
                    throw new Exception("Something went wrong");
                }
            }
        }

        public List<GetExpenseDTO> GetAllExpensesByUsername(string Username)
        {
            List<GetExpenseDTO> listToReturn = new List<GetExpenseDTO>();

            using (var context = new EconomiqContext())
            {
                var user = context.Users.Include(e => e.UserExpensesNav).ThenInclude(e=>e.CategoryNav).Include(e => e.RecipientNav).FirstOrDefault(x => x.UserName == Username);
                var expenses = user.UserExpensesNav.ToList();


                foreach (var expense in expenses)
                {
                    listToReturn.Add(new GetExpenseDTO { Amount = expense.Amount, Title = expense.Comment, ExpenseDate = expense.ExpenseDate.ToString("dd/MM/yyyy"), categoryName = expense.CategoryNav.CategoryName, RecipientName = expense.RecipientNav.Name }) ;

                }
                return listToReturn;
            }
        }

        public async Task<List<GetExpenseDTO>> GetRecentExpenses(string username)
        {
            List<GetExpenseDTO> recentExpenses = new();

            User? user = await _context.Users
                .Include(e => e.UserExpensesNav)
                .ThenInclude(e => e.CategoryNav)
                .Include(e => e.RecipientNav)
                .FirstOrDefaultAsync(x => x.UserName == username);

            List<Expense> expenses = user.UserExpensesNav
                .OrderByDescending(x => x.ExpenseDate)
                .Take(5)
                .ToList();

            foreach (var expense in expenses)
            {
                recentExpenses.Add(new GetExpenseDTO { Amount = expense.Amount, Title = expense.Comment, ExpenseDate = expense.ExpenseDate.ToString("dd/MM/yyyy"), categoryName = expense.CategoryNav.CategoryName, RecipientName = expense.RecipientNav.Name });
            }
            return recentExpenses;
        }
    }
}