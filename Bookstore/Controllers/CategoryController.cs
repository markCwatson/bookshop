using Microsoft.AspNetCore.Mvc;

namespace Bookstore.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View("Index");
        }
    }
}
