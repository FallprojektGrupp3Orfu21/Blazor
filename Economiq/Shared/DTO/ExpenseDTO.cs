using System.ComponentModel.DataAnnotations;

namespace Economiq.Shared.DTO
{
    public class ExpenseDTO
    {
        [Required(ErrorMessage = "Expense title required")]
#pragma warning disable CS8618 // Non-nullable property 'Title' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
        public string Title { get; set; }
#pragma warning restore CS8618 // Non-nullable property 'Title' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.

#pragma warning disable CS8618 // Non-nullable property 'ExpenseDate' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
        public string ExpenseDate { get; set; } // Currently needs format "Jan 1, 2009" or "2022-01-28" - Might not be used depending on Johannas opinion on Expense date (customizable to day expense happened or using date expense created in program.
#pragma warning restore CS8618 // Non-nullable property 'ExpenseDate' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.

        [Required(ErrorMessage = "Amount required")]
        [Range(1, double.MaxValue, ErrorMessage = "Amount has to be above 0")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "Category name required")]
#pragma warning disable CS8618 // Non-nullable property 'CategoryName' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
        public string CategoryName { get; set; }
#pragma warning restore CS8618 // Non-nullable property 'CategoryName' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.

#pragma warning disable CS8618 // Non-nullable property 'RecipientName' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
        public string RecipientName { get; set; }
#pragma warning restore CS8618 // Non-nullable property 'RecipientName' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
    }
}