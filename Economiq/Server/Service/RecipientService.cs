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

        public bool CreateRecipient(string userName, string recipientName, string recipientCity, string recipientStreet, string recipientZipcode)
        {
            var user = _context.Users.Where(user => user.UserName == userName).FirstOrDefault();
            if (user == null)
            {
                throw new Exception("No user with this username.");
            }
            var newRecipient = new Recipient
            {
                Name = recipientName,
                City = recipientCity,
                Street = recipientStreet,
                Zipcode = recipientZipcode
            };

            if (user.RecipientNav == null)
            {
                user.RecipientNav = new List<Recipient> { newRecipient };
            }

            user.RecipientNav.Add(newRecipient);

#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            try
            {
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
        }

        public List<RecipientDTO> GetRecipients(string Username, string? SearchString = null)
        {
            List<RecipientDTO> listToReturn = new List<RecipientDTO>();

            var user = _context.Users.Include(e => e.RecipientNav).FirstOrDefault(x => x.UserName == Username);
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8604 // Possible null reference argument for parameter 'source' in 'List<Recipient> Enumerable.ToList<Recipient>(IEnumerable<Recipient> source)'.
            var recipients = user.RecipientNav.ToList();
#pragma warning restore CS8604 // Possible null reference argument for parameter 'source' in 'List<Recipient> Enumerable.ToList<Recipient>(IEnumerable<Recipient> source)'.
#pragma warning restore CS8602 // Dereference of a possibly null reference.

            foreach (var recipient in recipients)
            {
                if (SearchString == null)
                {
                    listToReturn.Add(new RecipientDTO { Id = recipient.Id, Name = recipient.Name, City = recipient.City, Street = recipient.Street, Zipcode = recipient.Zipcode });
                }
                else if (recipient.Name.ToLower().StartsWith(SearchString.ToLower()))
                {
                    listToReturn.Add(new RecipientDTO { Id = recipient.Id, Name = recipient.Name, City = recipient.City, Street = recipient.Street, Zipcode = recipient.Zipcode });
                }
            }
            return listToReturn;
        }
    }
}