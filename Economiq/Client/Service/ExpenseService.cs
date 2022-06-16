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

        public async Task CreateExpense(ExpenseDTO expenseDTO)
        {
            await _apiService.GetExpenseClient().PostAsJsonAsync("createExpense", expenseDTO);
        }

        public async Task<List<GetExpenseDTO>> GetExpenses()
        {
            return await _apiService.GetExpenseClient().GetFromJsonAsync<List<GetExpenseDTO>>("listExpense");
        }
    }
}
