using Microsoft.AspNetCore.Mvc;
using OnlineShopping.Models;
using WebApplication1.Models;

namespace OnlineShopping.Controllers
{
    public class ContactController : Controller
    {
        private readonly Context _context;

        public ContactController(Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SubmitContactForm(ContactFormModel model)
        {
            if (ModelState.IsValid)
            {
                _context.ContactForms.Add(model);
                _context.SaveChanges();

                return RedirectToAction("ThankYou");
            }

            return View("Index", model);
        }
        public IActionResult ContactSubmissions()
        {
            //var submissions = _context.ContactForms.ToList();
            //return View(submissions);


            var submissions = _context.ContactForms.ToList();
            return PartialView("ContactSubmissions", submissions);
        }


        public IActionResult ThankYou()
        {
            return View();
        }
    }
}
