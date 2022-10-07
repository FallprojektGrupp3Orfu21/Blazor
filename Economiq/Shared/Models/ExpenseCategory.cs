using System.ComponentModel.DataAnnotations;

namespace Economiq.Shared.Models
{
    public class ExpenseCategory
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        [DataType(DataType.Date)]
        public DateTime CreationDate { get; set; }
        public List<Expense>? Expenses { get; set; }
        public List<User>? Users { get; set; }
    }
}