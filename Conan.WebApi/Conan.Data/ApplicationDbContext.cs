using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Conan.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace Conan.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Message> Messages { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Message>()
                .HasOne(m => m.FromUser)
                .WithMany()
                .HasForeignKey(k => k.FromUserId);

            builder.Entity<Message>()
                .HasOne(m => m.ToUser)
                .WithMany()
                .HasForeignKey(k => k.ToUserId);
        }



        //Data initialization methods

        public async void SeedDataAsync()
        {
            if (!EnumerableExtensions.Any(Users))
            {
                Users.AddRange(
                    new AppUser() { Id = "user1@gmail.com" },
                    new AppUser() { Id = "user2@gmail.com" },
                    new AppUser() { Id = "user3@gmail.com" },
                    new AppUser() { Id = "user4@gmail.com" });
                SaveChanges();
            }

            if (!EnumerableExtensions.Any(Messages) && 2 <= await Users.CountAsync())
            {
                try
                {
                    var users = Users.Take(2);
                    await Messages.AddRangeAsync(
                        new Message()
                        {
                            Body = "Hola, como esta?",
                            Date = DateTime.Today,
                            FromUser = users.FirstOrDefault(),
                            FromUserId = users.FirstOrDefault().Id,
                            ToUser = users.LastOrDefault(),
                            ToUserId = users.LastOrDefault().Id
                        },
                        new Message()
                        {
                            Body = "Gracias, muy bien, i to?",
                            Date = DateTime.Today,
                            FromUser = users.FirstOrDefault(),
                            FromUserId = users.FirstOrDefault().Id,
                            ToUser = users.LastOrDefault(),
                            ToUserId = users.LastOrDefault().Id
                        },
                        new Message()
                        {
                            Body = "Iqualmente",
                            Date = DateTime.Today,
                            FromUser = users.FirstOrDefault(),
                            FromUserId = users.FirstOrDefault().Id,
                            ToUser = users.LastOrDefault(),
                            ToUserId = users.LastOrDefault().Id
                        }
                    );
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        public async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
        {
            if (!await roleManager.RoleExistsAsync("Admin"))
            {
                var admin = new IdentityRole("Admin");
                await roleManager.CreateAsync(admin);
            }
        }
    }
}
