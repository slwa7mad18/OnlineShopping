using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShopping.Reposatory;
using OnlineShopping.Reposatory.ProductReposatory;
using WebApplication1.Models;

namespace OnlineShopping.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminDashboardController : Controller
    {
        private IReposatory<Category> _categoryReposatory { get; set; }
        private IProductReposatory _productReposatory { get; set; }
        public AdminDashboardController(IReposatory<Category> categoryReposatory, IProductReposatory productReposatory)
        {
            _categoryReposatory = categoryReposatory;
            _productReposatory = productReposatory;
        }

        public IActionResult Index()
        {
            // Get all non-deleted categories
            var categories = _categoryReposatory.GetAll().Where(c => c.IsDeleted == false).ToList();

            // Get all products within the non-deleted categories by checking CategoryId
            var categoriesIds = categories.Select(c => c.Id).ToList();
            var products = _productReposatory.GetAll().Where(p => categoriesIds.Contains(p.CategoryId)).ToList();

            // Create a Id/Name Dictionary to use later in filling the category Name by Id
            var categoriesIdsNames = categories.Select(c => new { Id = c.Id, Name = c.Name }).ToDictionary(x => x.Id, x => x.Name);

            // Count the number of products in each non-empty category
            var numberOfProductsForEachCategory = products.GroupBy(p => p.CategoryId)
                                             .Select(g => new { Id = g.Key, Name = categoriesIdsNames[g.Key], Count = g.Count() })
                                             .ToList();

            // Load the empty categories with Zero count
            foreach (var id in categoriesIds)
            {
                for (int i = 0; i < numberOfProductsForEachCategory.Count; i++)
                {
                    if (numberOfProductsForEachCategory[i].Id == id)
                    {
                        break;
                    }

                    if (i == numberOfProductsForEachCategory.Count - 1)
                    {
                        numberOfProductsForEachCategory.Add(new { Id = id, Name = categoriesIdsNames[id], Count = 0 });
                    }
                }
            }

            // Sort the categories by Id
            numberOfProductsForEachCategory = numberOfProductsForEachCategory.OrderBy(c => c.Id).ToList();

            var top10ProductsByPrice = products.OrderByDescending(p => p.Price).Take(10).ToList();

            ViewData["numberOfProductsForEachCategory_Names"] = numberOfProductsForEachCategory.Select(c => c.Name).ToList();
            ViewData["numberOfProductsForEachCategory_Counts"] = numberOfProductsForEachCategory.Select(c => c.Count).ToList();
            ViewData["top10ProductsByPrice_Names"] = top10ProductsByPrice.Select(p => p.Name).ToList();
            ViewData["top10ProductsByPrice_Prices"] = top10ProductsByPrice.Select(p => p.Price).ToList();
            //ViewData["top10ProductsByPrice"] = top10ProductsByPrice.Select(p => new { Name = p.Name, Price = p.Price }).ToList();
            ViewBag.top10ProductsByPrice = top10ProductsByPrice.Select(p => new { Name = p.Name, Price = p.Price }).ToList();
            return View();
        }
    }
}
