using System.ComponentModel.DataAnnotations;

namespace Economiq.Shared.Models
{
    public class ExpenseCategory
    {
        public int Id { get; set; }
#pragma warning disable CS8618 // Non-nullable property 'CategoryName' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
        public string CategoryName { get; set; }
#pragma warning restore CS8618 // Non-nullable property 'CategoryName' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.

        [DataType(DataType.Date)]
        public DateTime CreationDate { get; set; }

        //Navigational Properties
        //For Expenses
        public List<Expense>? ExpensesNav { get; set; }

        //For User
        public List<User>? UserNav { get; set; }
    }
}