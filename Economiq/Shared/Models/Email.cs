namespace Economiq.Shared.Models
{
    public class Email
    {
        private int Id { get; set; }

        [System.ComponentModel.DataAnnotations.EmailAddress]
#pragma warning disable CS8618 // Non-nullable property 'Mail' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
        public String Mail { get; set; }
#pragma warning restore CS8618 // Non-nullable property 'Mail' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.

        //Navigational Properties
#pragma warning disable CS8618 // Non-nullable property 'UserNav' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
        public User UserNav { get; set; }
#pragma warning restore CS8618 // Non-nullable property 'UserNav' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.

        public int UserNavId { get; set; }
    }
}