using Economiq.Shared.DTO;
using System.Net.Http.Json;

namespace Economiq.Client.Service
{
    public class ExpenseService
    {
        private readonly ApiService _apiService;

        public ExpenseService(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<string> CreateExpense(ExpenseDTO expenseDTO)
        {
            HttpResponseMessage response = await _apiService.GetExpenseClient().PostAsJsonAsync("createExpense", expenseDTO);
            string responseString = await response.Content.ReadAsStringAsync();
            return responseString;
        }

        public async Task<List<GetExpenseDTO>> GetExpenses()
        {
#pragma warning disable CS8603 // Possible null reference return.
            return await _apiService.GetExpenseClient().GetFromJsonAsync<List<GetExpenseDTO>>("listExpense");
#pragma warning restore CS8603 // Possible null reference return.
        }

        public async Task<List<GetExpenseDTO>> GetRecentExpenses()
        {
#pragma warning disable CS8603 // Possible null reference return.
            return await _apiService.GetExpenseClient().GetFromJsonAsync<List<GetExpenseDTO>>("getRecent");
#pragma warning restore CS8603 // Possible null reference return.
        }
    }
}