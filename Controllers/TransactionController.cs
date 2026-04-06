using Microsoft.AspNetCore.Mvc;
using FinanceTracker.Models;
using System.Threading.Tasks;

namespace FinanceTracker.Controllers
{
    public class TransactionController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TransactionController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(new Transaction());
        }

        [HttpPost]
        public async Task<IActionResult> Create(Transaction transaction)
        {
            ModelState.Clear(); // Clear all model state errors like Range or missing Date to force save

            _context.Add(transaction);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Dashboard");
        }
    }
}
