namespace Economiq.Shared.DTO
{
    public class GetExpenseDTO
    {
        public decimal Amount { get; set; }
#pragma warning disable CS8618 // Non-nullable property 'ExpenseDate' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
        public string ExpenseDate { get; set; }
#pragma warning restore CS8618 // Non-nullable property 'ExpenseDate' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
#pragma warning disable CS8618 // Non-nullable property 'categoryName' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
        public string categoryName { get; set; }
#pragma warning restore CS8618 // Non-nullable property 'categoryName' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
        public string? Title { get; set; }
#pragma warning disable CS8618 // Non-nullable property 'RecipientName' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
        public string RecipientName { get; set; }
#pragma warning restore CS8618 // Non-nullable property 'RecipientName' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
    }
}