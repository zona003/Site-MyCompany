using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyCompany.Domain.Entities;

namespace MyCompany.Domain
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<TextField> TextFields { get; set; }
        public DbSet<ServiceItem> ServiceItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "f4a4951a-75d1-43a4-8360-daa30d8f8697",
                Name = "admin",
                NormalizedName= "ADMIN"
            });

            modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser
            {
                Id = "03923909-4249-4f73-8050-94c6bf71b57e",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "my@email.com",
                NormalizedEmail = "MY@EMAIL.COM",
                EmailConfirmed = true,
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "superpassword"),
                SecurityStamp = string.Empty
            });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "f4a4951a-75d1-43a4-8360-daa30d8f8697",
                UserId = "03923909-4249-4f73-8050-94c6bf71b57e"
            });

            modelBuilder.Entity<TextField>().HasData(new TextField
            {
                Id = new System.Guid("86d1da90-4048-4a12-9f10-664cb6aa535b"),
                CodeWord = "PageIndex",
                Title = "Главная"
            });

            modelBuilder.Entity<TextField>().HasData(new TextField
            {
                Id = new System.Guid("614eb9d6-99d4-49bc-a4a3-49b5201c0a53"),
                CodeWord = "PageServices",
                Title = "Наши услуги"
            });

            modelBuilder.Entity<TextField>().HasData(new TextField
            {
                Id = new System.Guid("a14b7373-af5e-4319-a412-ef99128f9f12"),
                CodeWord = "PageContacts",
                Title = "Контакты"
            });
        }
    }
}
