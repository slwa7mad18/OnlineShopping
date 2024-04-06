
using Microsoft.AspNetCore.Mvc;
using OnlineShopping.Reposatory;
using WebApplication1.Models;

namespace OnlineShopping.Controllers
{
    public class CategoryController : Controller
    {
        IReposatory<Category> reposatory;
        public CategoryController(IReposatory<Category> reposatory)
        {

            this.reposatory = reposatory;
        }

        public IActionResult Index()
        {
            var allCategories = reposatory.GetAll();
            var visibleCategories = allCategories.Where(c => !c.IsDeleted);
            return View("Index", visibleCategories);

        }

        [HttpGet]
        public IActionResult New()
        {
            return View("New");
        }
        [HttpPost]
        public IActionResult SaveNew(Category category)
        {

            if (ModelState.IsValid)
            {
                reposatory.Insert(category);
                reposatory.Save();
                return RedirectToAction("Index");
            }
            return View("New", category);
        }
        [HttpGet]
        public IActionResult EditCategory(int id)
        {
            Category category = reposatory.GetById(id);
            if (category == null)
            {
                return NotFound("Category Not Found");
            }


            return View("EditCategory", category);
        }  
        [HttpPost]
        public IActionResult SaveEdit(Category updateCategory)
        {
            Category category = reposatory.GetById(updateCategory.Id);
            if (ModelState.IsValid)
            {
                category.Name = updateCategory.Name;
                reposatory.Update(category);
                reposatory.Save();
                return RedirectToAction("Index");
            }
            return View("EditCategory", category);

        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Category category = reposatory.GetById(id);
            if (category == null)
            {
                return NotFound("Category Not Found");
            }

            return View("Delete", category);
        }

        [HttpPost]
        public IActionResult SaveDelete(int id)
        {
            Category category = reposatory.GetById(id);
            if (category == null)
            {
                return NotFound("Category Not Found");
            }

            category.IsDeleted = true;

            reposatory.Update(category);
            reposatory.Save();

            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Search(string keyword)
        {
            var allCategories = reposatory.GetAll();
            var filteredCategories = allCategories.Where(c => !c.IsDeleted && c.Name.Contains(keyword));
            return View("Search", filteredCategories);
        }
    }
}
