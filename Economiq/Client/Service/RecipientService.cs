using Economiq.Shared.DTO;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Json;

namespace Economiq.Client.Service
{
    public class RecipientService
    {
        private readonly HttpClient _client;

        public RecipientService(HttpClient client)
        {
            _client = client;
        }

        public async Task<(HttpStatusCode, RecipientDTO)> CreateRecipient(RecipientDTO recipientDTO)
        {
            HttpResponseMessage response = await _client.PostAsJsonAsync("api/recipient/create", recipientDTO);
            string responseString = await response.Content.ReadAsStringAsync();
            RecipientDTO deserialized = JsonConvert.DeserializeObject<RecipientDTO>(responseString);
            return (response.StatusCode, deserialized);

        }

        public async Task<List<RecipientDTO>> GetRecipients(string? searchString = null)
        {
            HttpResponseMessage response = await _client.PostAsJsonAsync("api/recipient/getAll", searchString);
            string responseString = await response.Content.ReadAsStringAsync();
            List<RecipientDTO> deserialized = JsonConvert.DeserializeObject<List<RecipientDTO>>(responseString);
            return deserialized;
        }
    }
}
