namespace Economiq.Shared.Models
{
    public class Recipient
    {
        public int Id { get; set; }

#pragma warning disable CS8618 // Non-nullable property 'Name' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
        public string Name { get; set; }
#pragma warning restore CS8618 // Non-nullable property 'Name' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
        public string Street { get; set; } = String.Empty!;
        public string Zipcode { get; set; } = String.Empty!;
        public string City { get; set; } = String.Empty!;

        //Nav properties

        //For User
        public int UserNavId { get; set; }

        public User? UserNav { get; set; }

        //For Expense
        public List<Expense>? ExpenseNav { get; set; }
    }
}