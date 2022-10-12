using Economiq.Shared.DTO;
using Economiq.Shared.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Economiq.Shared.Extensions
{
    public static class BudgetExtensions
    {
        public static ListBudgetDTO ToListBudgetDTO(this Budget budget)
        {
            return new()
            {
                Id = budget.Id,
                MaxAmount = budget.MaxAmount,
                YearAndMonth = budget.StartDate.ToString("MMMM yyyy", new CultureInfo("en-GB")).FirstCharToUpper(),
            };
        }
    }
}
