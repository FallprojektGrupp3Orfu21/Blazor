using Economiq.Server.Data;
using Economiq.Shared.DTO;
using Economiq.Shared.Extensions;
using Economiq.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Economiq.Server.Service
{
    public class RecipientService
    {
        private readonly EconomiqContext _context;
        public RecipientService(EconomiqContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateRecipient(int userId, RecipientDTO dto)
        {

            var newRecipient = dto.ToRecipient(userId);
            _context.Recipients.Add(newRecipient);
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public async Task<List<RecipientDTO>> GetRecipients(int userId, string? SearchString = null)
        {
            List<RecipientDTO> listToReturn = new List<RecipientDTO>();

            var recipients = await _context.Recipients.Where(e => e.UserId == userId).ToListAsync();


            foreach (var recipient in recipients)
            {
                if (SearchString == null)
                {
                    listToReturn.Add(recipient.ToRecipientDTO());
                }
                else if (recipient.Name.ToLower().StartsWith(SearchString.ToLower()))
                {
                    listToReturn.Add(recipient.ToRecipientDTO());
                }
            }
            return listToReturn;
        }

    }
}