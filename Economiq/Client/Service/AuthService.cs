using Economiq.Shared.DTO;
using System.Net.Http.Json;

namespace Economiq.Client.Service
{
    public class AuthService
    {
        
        private HttpClient _client;
        public AuthService(HttpClient client)
        {
            _client = client;
        }
        public async Task<string> Login(Credentials LoginCredentials)
        {
            HttpResponseMessage response = await _client.PostAsJsonAsync("api/authentication/login", LoginCredentials);
            var token = await response.Content.ReadAsStringAsync();
            return token;
        }
    }
}
