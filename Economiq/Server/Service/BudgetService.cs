using Economiq.Server.Data;
using Economiq.Shared.DTO;

namespace Economiq.Server.Service
{
    public class BudgetService
    {
        private readonly EconomiqContext _context;
        public BudgetService(EconomiqContext context)
        {
            _context = context;
        }

        public async Task CreateBudget(CreateBudgetDTO createBudgetDTO, string username)
        {

        }

        public async Task<List<ListBudgetDTO>> GetAllBudgets(string username)
        {
            return new();
        }

        public async Task<List<ListBudgetDTO>> GetBudgetById(Guid id, string username)
        {
            return new();
        }

        public async Task<ListBudgetDTO> GetLatestBudget(string username)
        {
            return new();
        }

        public async Task<ListBudgetDTO> GetBudgetByDate(string username)
        {
            return new();
        }

    }
}
