using System.ComponentModel.DataAnnotations;

namespace Economiq.Shared.Models
{
    public class Expense
    {
        public int Id { get; set; }
        [DataType(DataType.Currency)]
        public decimal Amount { get; set; }
        public DateTime ExpenseDate { get; set; }
        public DateTime CreationDate { get; set; }
        public string? Comment { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
        public int? CategoryId;
        public ExpenseCategory? Category { get; set; }
        public int? RecipientId { get; set; }
        public Recipient? Recipient { get; set; }
        public Budget? Budget { get; set; }
        public Guid? BudgetId { get; set; }
    }
}
