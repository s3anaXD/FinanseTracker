using System.Collections.Generic;

namespace FinanceTracker.Models
{
    public class DashboardViewModel
    {
        public decimal Saldo { get; set; }
        public IEnumerable<Transaction> Transactions { get; set; } = [];
    }
}
