﻿using Economiq.Shared.DTO;
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
                Name = recipient.Name,
                ExtraInfo = recipient.ExtraInfo
            };
        }

        public static Recipient ToRecipient(this RecipientDTO dto, int userId)
        {
            return new Recipient
            {
                Name = dto.Name,
                ExtraInfo = dto.ExtraInfo,
                UserId = userId
            };
        }
    }
}