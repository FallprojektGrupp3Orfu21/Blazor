using Economiq.Shared.DTO;
using System.Net.Http.Json;

namespace Economiq.Client.Service
{
    public class UserService
    {
        private readonly HttpClient _client;

        public UserService(HttpClient client)
        {
            _client = client;
        }

        public async Task<string> CreateUser(UserDTO userDTO)
        {
            HttpResponseMessage response = await _client.PostAsJsonAsync("api/user/register", userDTO);
            string responseString = await response.Content.ReadAsStringAsync();
            return responseString;
        }
    }
}
