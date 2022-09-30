namespace Economiq.Shared.DTO
{
    public class ListBudgetDTO
    {
        public Guid Id { get; set; }
        public decimal MaxAmount { get; set; }
        public string YearAndMonth { get; set; }
        public List<GetExpenseDTO>? Expenses { get; set; }
    }
}
