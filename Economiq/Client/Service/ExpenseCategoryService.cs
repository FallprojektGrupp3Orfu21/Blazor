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
        private readonly HttpClient _client;

        public ExpenseCategoryService(HttpClient client)
        {
            _client = client;
        }

        public async Task<(HttpStatusCode, ExpenseCategoryDTO)> CreateExpenseCategory(ExpenseCategoryDTO dto)
        {
            HttpResponseMessage response = await _client.PostAsJsonAsync("api/category/create", dto);
            string responseString = await response.Content.ReadAsStringAsync();
            ExpenseCategoryDTO deserialized = JsonConvert.DeserializeObject<ExpenseCategoryDTO>(responseString);
            return (response.StatusCode, deserialized);
        }


        public async Task<List<ExpenseCategoryDTO>> GetCategoryList()
        {
            return await _client.GetFromJsonAsync<List<ExpenseCategoryDTO>>("api/category/getAll");
        }

        public async Task<List<CategorySumDTO>> GetGraphInfo(Guid budgetId)
        {
            return await _client.GetFromJsonAsync<List<CategorySumDTO>>($"api/category/getGraphInfo/{budgetId}");
        }
    }
}
