using Bookstore.Data;
using Bookstore.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bookstore.Controllers
{
    public class CategoryController : Controller
    {
        // AppDbContext registered in the services
        private readonly AppDbContext _db;

        public CategoryController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            List<Category> categories = _db.Categories.ToList();
            return View(categories);
        }
    }
}
