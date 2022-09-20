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

        public async Task CreateBudget(CreateBudgetDTO createBudgetDTO)
        {

        }

        public async Task<List<ListBudgetDTO>> GetAllBudgets()
        {
            return new();
        }

        public async Task<List<ListBudgetDTO>> GetBudgetById(Guid id)
        {
            return new();
        }

        public async Task<ListBudgetDTO> GetLatestBudget()
        {
            return new();
        }

        public async Task<ListBudgetDTO> GetBudgetByDate()
        {
            return new();
        }

    }
}
