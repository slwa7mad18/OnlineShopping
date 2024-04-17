using System.Diagnostics;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OnlineShopping.Reposatory;
using OnlineShopping.Reposatory.ProductReposatory;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductReposatory reprositryProd;
        private readonly UserManager<ApplicationUser> userManager;
        IEnumerable<Product> listnow = new List<Product>();
        private int _brandID = 0;

        public HomeController(ILogger<HomeController> logger,
            IProductReposatory reprositryProd,
            UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            this.reprositryProd = reprositryProd;
            this.userManager = userManager;

        }

        public IActionResult Index()
        {
            return View(reprositryProd.GetAll());
        }
        public IActionResult Category ()
        {
            return PartialView("Products", reprositryProd.GetAll()); ;
        }


        [HttpGet]
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


        public IActionResult Privacy()
        {
            return View();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(int? statusCode)
        {



            // Default error view
            return View("NotFound");

        }




        public IActionResult Search(string search) //,int? page)
        {
            if (!string.IsNullOrEmpty(search))
            {
                IEnumerable<Product> listnew = reprositryProd.GetAll().Where(p => p.Name.ToLower().Contains(search.ToLower()));
                return PartialView("Products", listnew); //.ToPagedList(page ?? 1, 1));
            }
            else
            {
                return PartialView("Products", reprositryProd.GetAll());   //.ToPagedList(page ?? 1, 1));
            }
        }

    }
}
