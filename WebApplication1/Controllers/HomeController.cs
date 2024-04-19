using Microsoft.AspNetCore.Mvc;
using OnlineShopping.Reposatory;
using OnlineShopping.Reposatory.ProductReposatory;
using System;
using WebApplication1.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductReposatory reprositryProd;
        private readonly IReposatory<Category> categoryRepo;

        public HomeController(IProductReposatory reprositryProd, IReposatory<Category> categoryRepo)
        {
            this.reprositryProd = reprositryProd;
            this.categoryRepo = categoryRepo;
        }


        public IActionResult Index()
        {
            ViewBag.Categories = categoryRepo.GetAll().Where(c => !c.IsDeleted);
            var products = reprositryProd.GetAll();
            return View(products);
        }

        public IActionResult FilterProduct(int categoryId)
        {
            var productsInCategory = reprositryProd.GetProductsByCategory(categoryId);
            return View( productsInCategory);
        }

    



    public IActionResult GetProduct(int Id)
        {
            var allProducts = reprositryProd.GetAll();
            var currentProduct = allProducts.FirstOrDefault(p => p.Id == Id);
            var randomProducts = allProducts.Except(new List<Product> { currentProduct }).OrderBy(x => Guid.NewGuid()).Take(4);
            var randomProducts2 = allProducts.Except(randomProducts).OrderBy(x => Guid.NewGuid()).Take(4);
            var randomProducts3 = allProducts.Except(randomProducts2).OrderBy(x => Guid.NewGuid()).Take(4);

            ViewData["Products"] = randomProducts.ToList();
            ViewData["Products2"] = randomProducts2.ToList();
            ViewData["Products3"] = randomProducts3.ToList();
            var product = reprositryProd.GetById(Id);
            return View(product);
        }

        public IActionResult Search(string search)
        {
            if (!string.IsNullOrEmpty(search))
            {
                var filteredProducts = reprositryProd.GetAll().Where(p => p.Name.ToLower().Contains(search.ToLower()));
                return PartialView("Products", filteredProducts);
            }
            else
            {
                // Return all products if search is empty
                var allProducts = reprositryProd.GetAll();
                return PartialView("Products", allProducts);
            }
        }

        public IActionResult Categories()
        {
            var categories = categoryRepo.GetAll();
            return View(categories);
        }
    }
}
