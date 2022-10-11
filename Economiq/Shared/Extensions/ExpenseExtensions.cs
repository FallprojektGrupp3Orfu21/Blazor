using Economiq.Shared.DTO;
using Economiq.Shared.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            return new Expense()
            {
                Amount = expense.Amount, 
                CreationDate = DateTime.Now,
                ExpenseDate = expenseDate,
                Comment = expense.Title, 
                UserId = userId,
                CategoryId = expense.CategoryId,
                RecipientId = expense.RecipientId
            };
        }
    }
}
