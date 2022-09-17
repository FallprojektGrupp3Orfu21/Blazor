using System.ComponentModel.DataAnnotations;

namespace Economiq.Shared.Models
{
    public class User
    {
        public int Id { get; set; }
#pragma warning disable CS8618 // Non-nullable property 'UserName' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
        public string UserName { get; set; }
#pragma warning restore CS8618 // Non-nullable property 'UserName' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
#pragma warning disable CS8618 // Non-nullable property 'Password' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
        public string Password { get; set; } //Is this really needed if using jwt authentication?
#pragma warning restore CS8618 // Non-nullable property 'Password' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
#pragma warning disable CS8618 // Non-nullable property 'Fname' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
        public string Fname { get; set; }
#pragma warning restore CS8618 // Non-nullable property 'Fname' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
#pragma warning disable CS8618 // Non-nullable property 'Lname' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
        public string Lname { get; set; }
#pragma warning restore CS8618 // Non-nullable property 'Lname' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
#pragma warning disable CS8618 // Non-nullable property 'Gender' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
        public string Gender { get; set; }
#pragma warning restore CS8618 // Non-nullable property 'Gender' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
#pragma warning disable CS8618 // Non-nullable property 'City' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
        public string City { get; set; }
#pragma warning restore CS8618 // Non-nullable property 'City' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.

        [DataType(DataType.Date)]
        public DateTime CreationDate { get; set; }

        //Navigational Properties
        //For Expense
        public List<Expense>? UserExpensesNav { get; set; }

        //For ExpenseCategory
        public List<ExpenseCategory>? ExpensesCategoryNav { get; set; }

        //Email
#pragma warning disable CS8618 // Non-nullable property 'Emails' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
        public List<Email> Emails { get; set; }
#pragma warning restore CS8618 // Non-nullable property 'Emails' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.

        public bool IsLoggedIn { get; set; }

        //For recipients
        public List<Recipient>? RecipientNav { get; set; }
    }
}