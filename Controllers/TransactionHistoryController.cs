using Microsoft.AspNetCore.Mvc;
using FinanceTracker.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace FinanceTracker.Controllers
{
    public class TransactionHistoryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TransactionHistoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var transactions = await _context.Transactions
                .OrderByDescending(t => t.Date)
                .ToListAsync();

            return View(transactions);
        }
    }
}
