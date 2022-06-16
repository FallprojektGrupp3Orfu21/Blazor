using Economiq.Shared.DTO;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace Economiq.Client.Service
{
    public class RecipientService
    {
        private readonly ApiService _apiService;

        public RecipientService(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task CreateRecipient(RecipientDTO recipientDTO)
        {
            await _apiService.GetRecipientClient().PostAsJsonAsync("createRecipient", recipientDTO);
        }

        public async Task<List<RecipientDTO>> GetRecipients(string? searchString = null)
        {
            HttpResponseMessage response = await _apiService.GetRecipientClient().PostAsJsonAsync("listRecipients", searchString);
            string responseString = await response.Content.ReadAsStringAsync();
            List<RecipientDTO> deserialized = JsonConvert.DeserializeObject<List<RecipientDTO>>(responseString);
            return deserialized;
        }
    }
}
