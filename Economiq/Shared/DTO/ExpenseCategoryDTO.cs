namespace Economiq.Shared.DTO
{
    public class ExpenseCategoryDTO
    {
        public string CategoryName { get; set; }
        public int CategoryId { get; set; }
        public List<GetExpenseDTO> Expenses { get; set; } 



    }
}