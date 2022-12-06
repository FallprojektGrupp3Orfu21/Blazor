using Economiq.Shared.DTO;
using Economiq.Shared.Models;

namespace Economiq.Shared.Extensions
{
    public static class RecipientExtensions
    {
        public static RecipientDTO ToRecipientDTO(this Recipient recipient)
        {
            if (!string.IsNullOrEmpty(recipient.ExtraInfo))
            {
                recipient.ExtraInfo = recipient.ExtraInfo.FirstCharToUpper();
            }
            return new RecipientDTO
            {
                Id = recipient.Id,
                Name = recipient.Name.FirstCharToUpper(),
                ExtraInfo = recipient.ExtraInfo
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
