using Microsoft.AspNetCore.Identity;
using WebApplication1.Models;

namespace OnlineShopping.Models
{
    public class Initializer
    {
        public UserManager<ApplicationUser> _UserManager { get; set; }
        public RoleManager<IdentityRole> _RoleManager { get; set; }

        public Initializer(UserManager<ApplicationUser> UserManager, RoleManager<IdentityRole> RoleManager)
        {
            _UserManager = UserManager;
            _RoleManager = RoleManager;
        }


        public async Task<bool> Initialize()
        {
            try
            {
                //var roleExist = await _RoleManager.FindByNameAsync("Admin");
                if (!await _RoleManager.RoleExistsAsync("Admin"))
                {
                    await _RoleManager.CreateAsync(new IdentityRole("Admin"));
                }

                var emailExist = await _UserManager.FindByEmailAsync("salwahammad18@gmail.com");
                if (emailExist == null)
                {
                    var user = new ApplicationUser()
                    {
                        UserName = "salwahammad18@gmail.com",
                        Email = "salwahammad18@gmail.com",
                        FirstName = "Salwa",
                        LastName = "Hammad",
                        Adress = "Minia , Egypt",
                        PhoneNumber = "01120080013"
                    };

                    var userResult = await _UserManager.CreateAsync(user, "dodo@Soly18111999");
                    await _UserManager.AddToRoleAsync(user, "Admin");
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
