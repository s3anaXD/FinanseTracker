using Microsoft.AspNetCore.Mvc;

namespace FinanceTracker.Controllers
{
    public class EditTransactionController : Controller
    {
        private readonly FinanceTracker.Models.ApplicationDbContext _context;

        public EditTransactionController(FinanceTracker.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        public async System.Threading.Tasks.Task<IActionResult> Index(int id)
        {
            var transaction = await _context.Transactions.FindAsync(id);
            if (transaction == null)
            {
                return NotFound();
            }
            return View(transaction);
        }

        [HttpPost]
        public async System.Threading.Tasks.Task<IActionResult> Edit(FinanceTracker.Models.Transaction transaction)
        {
            ModelState.Clear();
            _context.Update(transaction);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Dashboard");
        }
    }
}