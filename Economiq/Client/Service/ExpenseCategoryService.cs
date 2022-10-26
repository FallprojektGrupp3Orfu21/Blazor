using Economiq.Shared.DTO;
using System.Net.Http.Json;
using Economiq.Shared;
using Economiq.Shared.Models;
using System.Diagnostics.Metrics;
using System.Net;
using Newtonsoft.Json;

namespace Economiq.Client.Service
{
    public class ExpenseCategoryService
    {
        private readonly ApiService _apiService;

        public ExpenseCategoryService(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<(HttpStatusCode,ExpenseCategoryDTO)> CreateExpenseCategory(ExpenseCategoryDTO dto)
        {
            HttpResponseMessage response = await _apiService.GetExpenseCategoryClient().PostAsJsonAsync("create", dto);
            string responseString = await response.Content.ReadAsStringAsync();
            ExpenseCategoryDTO deserialized = JsonConvert.DeserializeObject<ExpenseCategoryDTO>(responseString);
            return (response.StatusCode, deserialized);   
        }


        public async Task<List<ExpenseCategoryDTO>> GetCategoryList()
        {
            return await _apiService.GetExpenseCategoryClient().GetFromJsonAsync<List<ExpenseCategoryDTO>>("listCategories");
        }

        public async Task<List<CategorySumDTO>> GetGraphInfo()
        {
            return await _apiService.GetExpenseCategoryClient().GetFromJsonAsync<List<CategorySumDTO>>("getGraphInfo");
        }
    }
}
