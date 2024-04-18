using Microsoft.AspNetCore.Mvc;

namespace OnlineShopping.Controllers
{
    public class AboutUsController : Controller
    {
        public IActionResult AboutUs()
        {
            return View();
        }
    }
}
