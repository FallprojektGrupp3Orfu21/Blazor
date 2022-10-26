using System.ComponentModel.DataAnnotations;

namespace Economiq.Shared.DTO
{
    public class RecipientDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Recipient Name Required")]
        public string Name { get; set; }
        public string ExtraInfo { get; set; } = String.Empty;

        
    }
}