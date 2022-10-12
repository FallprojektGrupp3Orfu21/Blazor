using Economiq.Shared.DTO;
using System.Net.Http.Json;

namespace Economiq.Client.Service
{
    public class BudgetService
    {
        private readonly ApiService _apiService;
        private HttpClient client;
        public BudgetService(ApiService apiService)
        {
            _apiService = apiService;
            client = _apiService.GetBudgetClient();
        }

        public async Task<List<ListBudgetDTO>> GetAllBudgets()
        {
            List<ListBudgetDTO> budgets = await client.GetFromJsonAsync<List<ListBudgetDTO>>("listBudgets");
            return budgets;
        }

        public async Task<ListBudgetDTO> GetBudgetById(Guid id)
        {

            ListBudgetDTO budget = await client.GetFromJsonAsync<ListBudgetDTO>($"getBudgetById/{id}");
            return budget;
        }

        public async Task<string> CreateBudget(CreateBudgetDTO createBudgetDTO)
        {
            HttpResponseMessage response = await _apiService
                .GetBudgetClient()
                .PostAsJsonAsync("createBudget", createBudgetDTO);
            string responseString = await response.Content
           .ReadAsStringAsync();
            return responseString;
        }
        public async Task<ListBudgetDTO> GetBudgetByDate(int yearAndMonth)
        {
            ListBudgetDTO budgetDate = await client.GetFromJsonAsync<ListBudgetDTO>($"{yearAndMonth}");
            return budgetDate;
        }
        public async Task<ListBudgetDTO> GetBudgetByMaxAmount(decimal maxAmount)
        {
            ListBudgetDTO budgetMaxAmount = await client.GetFromJsonAsync<ListBudgetDTO>($"{maxAmount}");
            return budgetMaxAmount;
        }



    }
}
