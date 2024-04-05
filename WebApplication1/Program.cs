using System.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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
             => options.UseSqlServer(@"Data Source=DESKTOP-N8IT99F;Initial Catalog=OnlineShopping;Integrated Security=True;Trust Server Certificate=true"));
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(
                options => { options.Password.RequiredLength = 8; })
                .AddEntityFrameworkStores<Context>();

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
