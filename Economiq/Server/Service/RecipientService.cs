using Economiq.Server.Data;
using Economiq.Shared.DTO;
using Economiq.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Service
{
    public class RecipientService
    {

        public bool CreateRecipient(string userName, string recipientName, string recipientCity)
        {
            using (var context = new EconomiqContext())
            {
                var user = context.Users.Where(user => user.UserName == userName).FirstOrDefault();
                if (user == null)
                {
                    throw new Exception("No user with this username.");
                }
                var newRecipient = new Recipient
                {
                    Name = recipientName,
                    City = recipientCity,
                };

                if (user.RecipientNav == null)
                {
                    user.RecipientNav = new List<Recipient> { newRecipient };
                }

                user.RecipientNav.Add(newRecipient);

                try
                {
                    context.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

        }

        public List<RecipientDTO> GetRecipients(string Username,string? SearchString = null)
        {
            List<RecipientDTO> listToReturn = new List<RecipientDTO>();

            using (var context = new EconomiqContext())
            {
                var user = context.Users.Include(e => e.RecipientNav).FirstOrDefault(x => x.UserName == Username);
                var recipients = user.RecipientNav.ToList();

                foreach (var recipient in recipients)
                {
                    if(SearchString == null) { 
                    listToReturn.Add(new RecipientDTO { Id= recipient.Id, Name = recipient.Name, City = recipient.City });
                    }
                    else if (recipient.Name.ToLower().StartsWith(SearchString.ToLower()))
                    {
                        listToReturn.Add(new RecipientDTO { Id = recipient.Id, Name = recipient.Name, City = recipient.City});
                    }
                }
                return listToReturn;


            }
        }

    }
}