using Economiq.Shared.DTO;
using System.Net.Http.Json;

namespace Economiq.Client.Service
{
    public class UserService
    {
        private readonly ApiService _apiService;

        public UserService(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task CreateUser(UserDTO userDTO)
        {
            await _apiService.GetUserClient().PostAsJsonAsync("createUser", userDTO);
        }

        public async Task Login()
        {
            await _apiService.GetUserClient().PostAsJsonAsync("login", String.Empty);
        }
    }
}
