using Economiq.Shared.DTO;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace Economiq.Client.Service
{
    public class BudgetService
    {
        private HttpClient _client;
        public BudgetService(HttpClient client)
        {
            _client = client;
        }

        public async Task<List<ListBudgetDTO>> GetAllBudgets()
        {
            List<ListBudgetDTO> budgets = await _client.GetFromJsonAsync<List<ListBudgetDTO>>("api/budget/getAll");
            return budgets;
        }

        public async Task<ListBudgetDTO> GetBudgetById(Guid id)
        {

            ListBudgetDTO budget = await _client.GetFromJsonAsync<ListBudgetDTO>($"api/budget/getById/{id}");
            return budget;
        }

        public async Task<Guid> CreateBudget(CreateBudgetDTO createBudgetDTO)
        {
            HttpResponseMessage response = await _client
                .PostAsJsonAsync("api/budget/create", createBudgetDTO);
            string responseString = await response.Content
           .ReadAsStringAsync();
            responseString = responseString.Replace("\"", "");
            return Guid.Parse(responseString);
        }
        public async Task<ListBudgetDTO> GetBudgetByDate(CreateBudgetDTO dto)
        {
            HttpResponseMessage response = await _client
                .PostAsJsonAsync("api/budget/getByDate", dto);
            string responseString = await response.Content.ReadAsStringAsync();
            ListBudgetDTO deserialized = JsonConvert.DeserializeObject<ListBudgetDTO>(responseString);
            return deserialized;
        }
        public async Task<decimal> GetLatestMaxAmount()
        {
            decimal budgetMaxAmount = await _client.GetFromJsonAsync<decimal>("api/budget/getLatestMaxAmount");
            return budgetMaxAmount;
        }



    }
}
