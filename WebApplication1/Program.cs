
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineShopping.Reposatory;
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
             => options.UseSqlServer(@"Data Source=.;Initial Catalog=OnlineShopping;Integrated Security=True;Trust Server Certificate=true"));
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(
                options => { options.Password.RequiredLength = 8; })
                .AddEntityFrameworkStores<Context>();
            builder.Services.AddScoped<IReposatory<Category>, GenaricReposatory<Category>>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
