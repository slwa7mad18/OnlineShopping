using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NuGet.Protocol.Core.Types;
using OnlineShopping.Reposatory;
using OnlineShopping.Reposatory.ProductReposatory;
using OnlineShopping.ViewModel.Product;
using WebApplication1.Models;

namespace OnlineShopping.Controllers
{
   //[Authorize(Roles ="Admin")]
    public class ProductController : Controller
    {
        public IProductReposatory ProductReposatory { get; set; }
        public IReposatory<Category> CategoryRepo { get; }
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductController(IProductReposatory productReposatory
            ,IReposatory<Category> categoryRepo,IWebHostEnvironment webHostEnvironment )
        {
            ProductReposatory = productReposatory;
            CategoryRepo = categoryRepo;
            _webHostEnvironment = webHostEnvironment;
        }


        public IActionResult Index()
        {
            //var DeletedCat=CategoryRepo.GetAll().Where(e => e.IsDeleted == true);
            ViewBag.PageCount = (int)Math.Ceiling((decimal)ProductReposatory.GetAll().Count() / 5m);
            return View(this.ProductReposatory.GetAll());

        }
        public IActionResult GetAll(int PageNum,int pageSize = 5)
        {
            var products = ProductReposatory.GetAll()
                .OrderBy(p=>p.Id).Skip((PageNum-1)*pageSize)
                .Take(pageSize).ToList();
            return PartialView("_ProductTable", products);


        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            Product product = ProductReposatory.GetById(id);
            return View(product);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewData["CategoryId"]=new SelectList(CategoryRepo.GetAll().Where(e=>e.IsDeleted==false), "Id", "Name");
            return View();
        }
        [HttpPost,ValidateAntiForgeryToken]
        public IActionResult Create(AddProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Product insertProduct = new Product()
                    {
                        Name = model.Name,
                        Count = model.Count,
                        CategoryId = model.CategoryId,
                        Price = model.Price,
                        Description = model.Description,    
                        ImgUrl= ProductReposatory.UploadFile(model.ImgUrl),
                    };

                    ProductReposatory.Insert(insertProduct);
                    ProductReposatory.Save();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("",ex.Message);
                    ViewData["CategoryId"]=new SelectList(CategoryRepo.GetAll(),"Id", "Name");
                    return View(model);

                }

            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var product=ProductReposatory.GetById(Id);
            EditProductViewModel model = new EditProductViewModel()
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Count = product.Count,
                CategoryId = product.CategoryId,
            };
            ViewData["CategoryId"] = new SelectList(CategoryRepo.GetAll().Where(e=>e.IsDeleted==false), "Id", "Name"
                , CategoryRepo.GetById(model.CategoryId));
                return View(model);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Edit(EditProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    ProductReposatory.Update(model);
                    ProductReposatory.Save();
                    return RedirectToAction("Index");

                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    ViewData["CategoryId"] = new SelectList(CategoryRepo.GetAll(), "Id", "Name"
                        , CategoryRepo.GetById(model.CategoryId));
                    return View(model);
                }
            }
            else
            {
                ViewData["CategoryId"] = new SelectList(CategoryRepo.GetAll(), "Id", "Name"
                    , CategoryRepo.GetById(model.CategoryId));
                return View(model);
            }
        }
        public IActionResult CheckProduct(string Name)
        {
            if (ProductReposatory.CheckProduct(Name))
            {
                return Json(true);
            }
            else
            {
                return Json(false);
            }
        }
        public IActionResult CheckProductToEdit(string Name,int Id)
        {
            if (ProductReposatory.CheckProductToEdit(Name,Id))
            {
                return Json(true);
            }
            else
            {
                return Json(false);
            }

        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Product product = ProductReposatory.GetById(id);
            if (product == null)
            {
                return NotFound("Product Not Found");
            }

            return View("Delete", product);
        }

        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult ConfirmDelete(int Id)
        {
                ProductReposatory.Delete(Id);
                ProductReposatory.Save();
                return RedirectToAction("Index");
        }



        //Review Action
        public IActionResult AddReview()
        {
            return View("AddReview");
        }
        
    }
}
