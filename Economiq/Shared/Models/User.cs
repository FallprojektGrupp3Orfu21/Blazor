using System.ComponentModel.DataAnnotations;

namespace Economiq.Shared.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Salt { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreationDate { get; set; }
        public List<Expense>? Expenses { get; set; }
        public List<ExpenseCategory>? Categories { get; set; }
        public List<Email> Emails { get; set; }
        public List<Recipient>? Recipients { get; set; }
        public List<Budget> Budgets { get; set; }
    }
}