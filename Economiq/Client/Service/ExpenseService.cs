using Economiq.Shared.DTO;
using System.Net.Http.Json;

namespace Economiq.Client.Service
{
    public class ExpenseService
    {
        private readonly HttpClient _client;

        public ExpenseService(HttpClient client)
        {
            _client = client;
        }

        public async Task<string> CreateExpense(ExpenseDTO expenseDTO)
        {
            HttpResponseMessage response = await _client.PostAsJsonAsync("api/expense/create", expenseDTO);
            string responseString = await response.Content.ReadAsStringAsync();
            return responseString;
        }

        public async Task<List<GetExpenseDTO>> GetExpenses()
        {
            return await _client.GetFromJsonAsync<List<GetExpenseDTO>>("api/expense/getAll");
        }

        public async Task<List<GetExpenseDTO>> GetRecentExpenses()
        {
            return await _client.GetFromJsonAsync<List<GetExpenseDTO>>("api/expense/getRecent");
        }

        public async Task<HttpResponseMessage> DeleteExpense(int DeleteExpenseId)
        {
            HttpResponseMessage _response = await _client.DeleteAsync($"api/expense/{DeleteExpenseId.ToString()}");
            return _response;
        }

    }
}
