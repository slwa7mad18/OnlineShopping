using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShopping.Reposatory.ProductReposatory;
using OnlineShopping.Reposatory.ReviewReprositry;

namespace OnlineShopping.Controllers
{

    [Authorize(Roles = "Admin")]

    public class ReviewController : Controller
    {
        public IReviewReprositry ReviewReprositry { get; }
        public IProductReposatory ProductReprository { get; }

        public ReviewController(IReviewReprositry reviewReprositry, IProductReposatory productReprository)
        {
            ReviewReprositry = reviewReprositry;
            ProductReprository = productReprository;
        }
        public IActionResult Index()
        {
            return View(ReviewReprositry.GetAllProductThatHaveRevies());
        }

        public IActionResult GetReviews(int Id)
        {
            var product = ProductReprository.GetById(Id);
            ViewBag.ProductName = product.Name;
            return View(ReviewReprositry.GetReviewsOnSpecificProduct(product.Id));
        }
    }
}
