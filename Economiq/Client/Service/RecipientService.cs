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

        public async Task<string> CreateRecipient(RecipientDTO recipientDTO)
        {
            HttpResponseMessage response = await _apiService.GetRecipientClient().PostAsJsonAsync("createRecipient", recipientDTO);
            string responseString = await response.Content.ReadAsStringAsync();
            return responseString;
        }

        public async Task<List<RecipientDTO>> GetRecipients(string? searchString = null)
        {
            HttpResponseMessage response = await _apiService.GetRecipientClient().PostAsJsonAsync("listRecipients", searchString);
            string responseString = await response.Content.ReadAsStringAsync();
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            List<RecipientDTO> deserialized = JsonConvert.DeserializeObject<List<RecipientDTO>>(responseString);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS8603 // Possible null reference return.
            return deserialized;
#pragma warning restore CS8603 // Possible null reference return.
        }
    }
}