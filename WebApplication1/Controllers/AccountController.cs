using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShopping.Models;
using OnlineShopping.ViewModel;
using WebApplication1.Models;

namespace OnlineShopping.Controllers
{
    public class AccountController : Controller
    {

        public UserManager<ApplicationUser> UserManager { get; set; }
        public SignInManager<ApplicationUser> SignInManager { get; set; }
        private RoleManager<IdentityRole> _RoleManager { get; set; }
        private Initializer _adminInitializer { get; set; }

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> RoleManager, Initializer adminInitializer)
        {
            UserManager = userManager;
            SignInManager = signInManager;
            _RoleManager = RoleManager;
            _adminInitializer = adminInitializer;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
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
                    PhoneNumber = newUser.PhoneNumber,
                    Adress=newUser.Address
                };
                IdentityResult result = await UserManager.CreateAsync(oldUser, newUser.Password);
                if (result.Succeeded)
                {
                    var UserRole = await _RoleManager.FindByNameAsync("User");
                    if (UserRole == null)
                    {
                        await _RoleManager.CreateAsync(new IdentityRole("User"));
                    }

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
        public async Task<IActionResult> Login()
        {
            await _adminInitializer.Initialize();
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
                        var IsAdmin= await UserManager.IsInRoleAsync(userDB, "Admin");
                        if (IsAdmin)
                        {
                            await SignInManager.SignInAsync(userDB, uservm.RememberMe);

                            return RedirectToAction("Index", "AdminDashboard");

                        }
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
