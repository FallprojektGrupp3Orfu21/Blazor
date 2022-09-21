using Economiq.Shared.DTO;
using System.Net.Http.Json;

namespace Economiq.Client.Service
{
    public class BudgetService
    {
        private readonly ApiService _apiService;

        public BudgetService(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<List<ListBudgetDTO>> GetAllBudgets()
        {
            return await _apiService.GetBudgetClient().GetFromJsonAsync<List<ListBudgetDTO>>("listBudgets");
        }

        public async Task<List<ListBudgetDTO>> GetBudgetById(Guid id)
        {
            return await _apiService.GetBudgetClient().GetFromJsonAsync<List<ListBudgetDTO>>($"getBudgetById/{id}");
        }
    }
}
