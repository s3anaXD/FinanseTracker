using Microsoft.AspNetCore.Mvc;

namespace FinanceTracker.Controllers
{
    public class RulesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
