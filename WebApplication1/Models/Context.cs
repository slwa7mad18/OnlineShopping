using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineShopping.Models;

namespace WebApplication1.Models
{
    public class Context : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Review> reviews { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<OrderItem> orderItems { get; set; }
        public DbSet<Cart> carts { get; set; }


        public DbSet<ContactFormModel> ContactForms { get; set; }

        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=.;Initial Catalog=OnlineShopping;Integrated Security=True;Trust Server Certificate=true");
        }
        protected override async void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //const string ADMIN_ID = "dodo-soly-18111999";
            //const string ROLE_ID_Admin = "dodo-soly-18111999";
            //const string ROLE_ID_USER = "soo-18";
            //var role = builder.Entity<IdentityRole>().HasData(
            //    new IdentityRole
            //    {
            //        Id = ROLE_ID_Admin,
            //        Name = "Admin",
            //        NormalizedName = "ADMIN"
            //    },
            //    new IdentityRole
            //    {
            //        Id = ROLE_ID_USER,
            //        Name = "User",
            //        NormalizedName = "USER"
            //    });
            //builder.Entity<ApplicationUser>().HasData(
            //     new ApplicationUser
            //     {
            //         Id = ADMIN_ID,
            //         Email = "salwahammad18@gmail.com",
            //         PasswordHash = "dodo@Soly18111999", 
            //         FirstName = "Salwa",
            //         LastName = "Hammad",
            //         Adress = "Minia , Egypt",
            //         PhoneNumber = "01120080013"
            //     });

            //builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            //{
            //    RoleId = ROLE_ID_Admin,
            //    UserId = ADMIN_ID
            //});


        }
    }
}
