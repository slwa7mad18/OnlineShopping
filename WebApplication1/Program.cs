using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineShopping.Models;
using OnlineShopping.Reposatory;
using OnlineShopping.Reposatory.ProductReposatory;
using WebApplication1.Models;

namespace WebApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<Context>(options
                => options.UseSqlServer(@"Data Source=.;Initial Catalog=OnlineShopping;Integrated Security=True;Trust Server Certificate=true")
                );

            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(
                options => { options.Password.RequiredLength = 8; })
                .AddUserManager<UserManager<ApplicationUser>>()
                .AddRoleManager<RoleManager<IdentityRole>>()
                .AddEntityFrameworkStores<Context>();

            builder.Services.AddScoped<IReposatory<Category>, GenaricReposatory<Category>>();
            builder.Services.AddScoped<IProductReposatory, ProductReposatory>();
            builder.Services.AddTransient<UserManager<ApplicationUser>>();
            builder.Services.AddTransient<RoleManager<IdentityRole>>();
            builder.Services.AddTransient<Initializer>();
            //builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
            //    .AddEntityFrameworkStores<Context>();


            builder.Services.AddSession();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.MapControllerRoute(
                name: "Dashbord",
                pattern: "{controller=AdminDashbord}/{action=Index}");

            
            app.Run();
            

        }
    }
}
