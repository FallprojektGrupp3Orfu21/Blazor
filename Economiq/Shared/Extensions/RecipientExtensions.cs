using Economiq.Shared.DTO;
using Economiq.Shared.Models;

namespace Economiq.Shared.Extensions
{
    public static class RecipientExtensions
    {
        public static RecipientDTO ToRecipientDTO(this Recipient recipient)
        {
            return new RecipientDTO
            {
                Id = recipient.Id,
                Name = recipient.Name.FirstCharToUpper(),
                ExtraInfo = recipient.ExtraInfo.FirstCharToUpper()
            };
        }

        public static Recipient ToRecipient(this RecipientDTO dto, int userId)
        {
            return new Recipient
            {
                Name = dto.Name.ToLower(),
                ExtraInfo = dto.ExtraInfo.ToLower(),
                UserId = userId
            };
        }
    }
}
