using Bookstore.Data;
using Bookstore.Models;
using Bookstore.Repositories.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace Bookstore.Controllers
{
    public class CategoryController : Controller
    {
        // AppDbContext registered in the services
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IActionResult Index()
        {
            List<Category> categories = _categoryRepository.GetAll().ToList();
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

            _categoryRepository.Add(newCategory);
            _categoryRepository.Save();
            TempData["success"] = "Category created successfully!";
            return RedirectToAction("Index", "Category");
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Category? category = _categoryRepository.Get(obj => obj.Id == id);
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

            _categoryRepository.Update(updatedCategory);
            _categoryRepository.Save();
            TempData["success"] = "Category updated successfully!";
            return RedirectToAction("Index", "Category");
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Category? category = _categoryRepository.Get(obj => obj.Id == id);
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

            Category? toDelete = _categoryRepository.Get(obj => obj.Id == id);
            if (toDelete == null)
            {
                return NotFound();
            }

            _categoryRepository.Delete(toDelete);
            _categoryRepository.Save();
            TempData["success"] = "Category deleted successfully!";
            return RedirectToAction("Index", "Category");
        }
    }
}
