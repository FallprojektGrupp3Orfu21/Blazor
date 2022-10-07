using Economiq.Server.Data;
using Economiq.Shared.DTO;
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
        public bool CreateRecipient(string userName, RecipientDTO dto)
        {
            var user = _context.Users.Where(user => user.UserName == userName).FirstOrDefault();
            if (user == null)
            {
                throw new Exception("No user with this username.");
            }
            var newRecipient = new Recipient
            {
                Name = dto.Name,
                ExtraInfo = dto.ExtraInfo
            };

            if (user.Recipients == null)
            {
                user.Recipients = new List<Recipient> { newRecipient };
            }

            user.Recipients.Add(newRecipient);

            try
            {
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false; 
            }
        }
        public List<RecipientDTO> GetRecipients(string Username, string? SearchString = null)
        {
            List<RecipientDTO> listToReturn = new List<RecipientDTO>();

            var user = _context.Users.Include(e => e.Recipients).FirstOrDefault(x => x.UserName == Username);
            var recipients = user.Recipients.ToList();

            foreach (var recipient in recipients)
            {
                if (SearchString == null)
                {
                    listToReturn.Add(new RecipientDTO { Id = recipient.Id, Name = recipient.Name, ExtraInfo = recipient.ExtraInfo });
                }
                else if (recipient.Name.ToLower().StartsWith(SearchString.ToLower()))
                {
                    listToReturn.Add(new RecipientDTO { Id = recipient.Id, Name = recipient.Name, ExtraInfo = recipient.ExtraInfo });
                }
            }
            return listToReturn;
        }

    }
}