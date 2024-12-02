using Bookstore.Data;
using Bookstore.Models;
using Bookstore.Repositories.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace Bookstore.Controllers
{
    public class CategoryController : Controller
    {
        // AppDbContext registered in the services
        private readonly IRepositoryManager _repoMgr;

        public CategoryController(IRepositoryManager repoMgr)
        {
            _repoMgr = repoMgr;
        }

        public IActionResult Index()
        {
            List<Category> categories = [.. _repoMgr.CategoryRepo.GetAll()];
            return View(categories);
        }

        public IActionResult Create()
        {
            return View(new Category());
        }

        [HttpPost]
        public IActionResult Create(Category newCategory)
        {
            if (!ModelState.IsValid)
            {
                return View("Create");
            }

            _repoMgr.CategoryRepo.Add(newCategory);
            _repoMgr.Save();
            TempData["success"] = "Category created successfully!";
            return RedirectToAction("Index", "Category");
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Category? category = _repoMgr.CategoryRepo.Get(obj => obj.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category updatedCategory)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit");
            }

            _repoMgr.CategoryRepo.Update(updatedCategory);
            _repoMgr.Save();
            TempData["success"] = "Category updated successfully!";
            return RedirectToAction("Index", "Category");
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Category? category = _repoMgr.CategoryRepo.Get(obj => obj.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Category? toDelete = _repoMgr.CategoryRepo.Get(obj => obj.Id == id);
            if (toDelete == null)
            {
                return NotFound();
            }

            _repoMgr.CategoryRepo.Delete(toDelete);
            _repoMgr.Save();
            TempData["success"] = "Category deleted successfully!";
            return RedirectToAction("Index", "Category");
        }
    }
}
