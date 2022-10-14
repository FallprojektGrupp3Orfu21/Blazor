using Economiq.Shared.DTO;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace Economiq.Client.Service
{
    public class BudgetService
    {
        private readonly ApiService _apiService;
        private HttpClient _client;
        public BudgetService(ApiService apiService)
        {
            _apiService = apiService;
            _client = _apiService.GetBudgetClient();
        }

        public async Task<List<ListBudgetDTO>> GetAllBudgets()
        {
            List<ListBudgetDTO> budgets = await _client.GetFromJsonAsync<List<ListBudgetDTO>>("listBudgets");
            return budgets;
        }

        public async Task<ListBudgetDTO> GetBudgetById(Guid id)
        {

            ListBudgetDTO budget = await _client.GetFromJsonAsync<ListBudgetDTO>($"getBudgetById/{id}");
            return budget;
        }

        public async Task<Guid> CreateBudget(CreateBudgetDTO createBudgetDTO)
        {
            HttpResponseMessage response = await _client
                .PostAsJsonAsync("createBudget", createBudgetDTO);
            string responseString = await response.Content
           .ReadAsStringAsync();
            responseString = responseString.Replace("\"", "");
            return Guid.Parse(responseString);
        }
        public async Task<ListBudgetDTO> GetBudgetByDate(CreateBudgetDTO dto)
        {
            HttpResponseMessage response = await _client
                .PostAsJsonAsync("getBudgetByDate", dto);
            string responseString = await response.Content.ReadAsStringAsync();
            ListBudgetDTO deserialized = JsonConvert.DeserializeObject<ListBudgetDTO>(responseString);
            return deserialized;
        }
        public async Task<decimal> GetLatestMaxAmount()
        {
            decimal budgetMaxAmount = await _client.GetFromJsonAsync<decimal>("getLatestMaxAmount");
            return budgetMaxAmount;
        }



    }
}
