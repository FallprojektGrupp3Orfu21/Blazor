namespace Economiq.Shared.Models
{
    public class Email
    {
        int Id { get; set; }
        [System.ComponentModel.DataAnnotations.EmailAddress]
        public String Mail { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
    }
}
