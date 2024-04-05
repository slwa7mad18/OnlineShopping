using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShopping.ViewModel;
using WebApplication1.Models;

namespace OnlineShopping.Controllers
{
    public class AccountController : Controller
    {

        public UserManager<ApplicationUser> UserManager { get; set; }
        public SignInManager<ApplicationUser> SignInManager { get; set; }

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost,ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel newUser)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser oldUser = new ApplicationUser()
                {
                    FirstName = newUser.FirstName,
                    LastName = newUser.LastName,
                    Email = newUser.Email,
                    PasswordHash = newUser.Password,
                    UserName = newUser.Email,
                    PhoneNumber = newUser.PhoneNumber
                };
                IdentityResult result=await UserManager.CreateAsync(oldUser,newUser.Password);
                if (result.Succeeded)
                {
                    await SignInManager.SignInAsync(oldUser, false);
                    await UserManager.AddToRoleAsync(oldUser, "User");
                    return RedirectToAction("Index", "Home");

                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }

            return View(newUser);
        }




        //login


        [HttpGet]
        public IActionResult Login()
        {
            return View("Login");
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel uservm)
        {
            if (ModelState.IsValid == true)
            {
                ApplicationUser userDB = await UserManager.FindByNameAsync(uservm.UserName);


                if (userDB != null)
                {
                    bool found = await UserManager.CheckPasswordAsync(userDB, uservm.Password);

                    if (found)
                    {
                        await SignInManager.SignInAsync(userDB, uservm.RememberMe);
                        return RedirectToAction("Index", "Home");
                    }
                }
                ModelState.AddModelError("", "Invalid Account");
            }
            return View("Login", uservm);
        }




        public async Task<IActionResult> SignOut()
        {

            await SignInManager.SignOutAsync();
            return RedirectToAction("Login");

        }







    }
}
