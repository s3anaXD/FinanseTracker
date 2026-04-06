using Microsoft.AspNetCore.Mvc;

namespace FinanceTracker.Controllers
{
    public class DeleteTransactionController : Controller
    {
        private readonly FinanceTracker.Models.ApplicationDbContext _context;

        public DeleteTransactionController(FinanceTracker.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        public async System.Threading.Tasks.Task<IActionResult> Index(int id)
        {
            var transaction = await _context.Transactions.FindAsync(id);
            if (transaction != null)
            {
                _context.Transactions.Remove(transaction);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index", "Dashboard");
        }
    }
}
