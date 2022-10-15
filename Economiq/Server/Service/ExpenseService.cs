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
            List<Expense> expenses = await _context.Expenses.Where(e => e.UserId == userId).Include(r => r.Recipient).ToListAsync();

            if (expenses == null)
            {
                expenses = new List<Expense>();
            }
            //Length Check for title/comment
            if (expense.Title.Length > 50)
            {
                throw new Exception("Title Too Long (Needs to be less than 50 characters)");
            }

            Expense newExpense = expense.ToExpense(userId);

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

        public async Task<List<GetExpenseDTO>> GetAllExpensesByUserId(int userId)
        {
            List<GetExpenseDTO> listToReturn = new List<GetExpenseDTO>();
            var expenses = await _context.Expenses.Where(e => e.UserId == userId).Include(e => e.Category).Include(e => e.Recipient).ToListAsync();

            foreach (var expense in expenses)
            {
                listToReturn.Add(expense.ToGetExpenseDTO());

            }
            return listToReturn;

        }

        public async Task<List<GetExpenseDTO>> GetRecentExpenses(int userId)
        {
            List<GetExpenseDTO> recentExpenses = new();

            var expenses = await _context.Expenses.Where(ex => ex.UserId == userId)
                .Include(ex => ex.Category)
                .Include(r => r.Recipient)
                .OrderByDescending(x => x.CreationDate)
                .Take(5)
                .ToListAsync();

            foreach (var expense in expenses)
            {
                recentExpenses.Add(expense.ToGetExpenseDTO());
            }
            return recentExpenses;

        }
    }
}