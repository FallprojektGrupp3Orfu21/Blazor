using Economiq.Shared.DTO;
using System.Net.Http.Json;

namespace Economiq.Client.Service
{
    public class ExpenseCategoryService
    {
        private readonly ApiService _apiService;

        public ExpenseCategoryService(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task CreateExpenseCategory(ExpenseCategoryDTO dto)
        {
            await _apiService.GetExpenseCategoryClient().PostAsJsonAsync("create", dto);
        }
    }
}
