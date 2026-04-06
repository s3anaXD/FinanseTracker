using Microsoft.AspNetCore.Mvc;
using FinanceTracker.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace FinanceTracker.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DashboardController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var recentTransactions = await _context.Transactions
                .OrderByDescending(t => t.Date)
                .Take(5)
                .ToListAsync();

            var allTransactions = await _context.Transactions
                .ToListAsync();

            decimal saldo = allTransactions.Sum(t => t.GetAmount());

            var model = new DashboardViewModel
            {
                Saldo = saldo,
                Transactions = recentTransactions
            };

            return View(model);
        }
    }
}
