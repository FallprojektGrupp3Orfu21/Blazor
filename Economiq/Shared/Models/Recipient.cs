namespace Economiq.Shared.Models
{
    public class Recipient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ExtraInfo { get; set; } = String.Empty!;
        public int UserId { get; set; }
        public User? User { get; set; }
        public List<Expense>? ExpenseNav { get; set; }
    }
}