namespace Economiq.Shared.DTO
{
    public class ExpenseDTO
    {
        public string Title { get; set; }
        public string ExpenseDate { get; set; } // Currently needs format "Jan 1, 2009" or "2022-01-28" - Might not be used depending on Johannas opinion on Expense date (customizable to day expense happened or using date expense created in program.
        public decimal Amount { get; set; }
        public string CategoryName { get; set; }
        public string RecipientName { get; set; }
    }
}