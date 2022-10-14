using Economiq.Shared.DTO;
using Economiq.Shared.Models;
using System.Globalization;

namespace Economiq.Shared.Extensions
{
    public static class ExpenseExtensions
    {
        public static GetExpenseDTO ToGetExpenseDTO(this Expense expense)
        {
            return new()
            {
                Amount = expense.Amount,
                categoryName = expense.Category.CategoryName,
                ExpenseDate = expense.ExpenseDate.ToString("dd/MM/yyyy", new CultureInfo("en-GB")),
                RecipientName = expense.Recipient.Name,
                Title = expense.Comment
            };
        }

        public static Expense ToExpense(this ExpenseDTO expense, int userId)
        {
            DateTime expenseDate = DateTime.Parse(expense.ExpenseDate).Date;
            var TExpense = new Expense()
            {
                Amount = expense.Amount,
                CreationDate = DateTime.Now,
                ExpenseDate = expenseDate,
                Comment = expense.Title.ToLower(),
                UserId = userId,
                CategoryId = expense.CategoryId,
                RecipientId = expense.RecipientId,
                BudgetId = expense.BudgetId
            };
            return TExpense;
        }
    }
}
