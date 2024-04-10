using Microsoft.AspNetCore.Identity;
using WebApplication1.Models;

namespace OnlineShopping.Models
{
    public class Initializer
    {
        private UserManager<ApplicationUser> _UserManager { get; set; }
        private RoleManager<IdentityRole> _RoleManager { get; set; }

        public Initializer()
        {
        }

        public Initializer(UserManager<ApplicationUser> UserManager, RoleManager<IdentityRole> RoleManager)
        {
            _UserManager = UserManager;
            _RoleManager = RoleManager;
        }


        public async void Initialize()
        {

            var roleExist = await _RoleManager.FindByNameAsync("Admin");
            if (roleExist == null)
            {
                await _RoleManager.CreateAsync(new IdentityRole("Admin"));

                var emailExist = await _UserManager.FindByNameAsync("salwahammad18@gmail.com");
                if (emailExist == null)
                {
                    var app = new ApplicationUser()
                    {
                        Email = "salwahammad18@gmail.com",
                        FirstName = "Salwa",
                        LastName = "Hammad",
                        Adress = "Minia , Egypt",
                        PhoneNumber = "01120080013"

                    };

                    await _UserManager.CreateAsync(app, "dodo@Soly18111999");
                    await _UserManager.AddToRoleAsync(app, "Admin");
                }
            }
        }
    }
}
