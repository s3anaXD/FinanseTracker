using Microsoft.AspNetCore.Mvc;

namespace FinanceTracker.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
