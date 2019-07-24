using System;
using System.Collections.Generic;
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
                .HasOne<AppUser>(a => a.Sender)
                .WithMany(m => m.Messages)
                .HasForeignKey(f => f.SenderID);

            builder.Entity<Message>()
                .HasOne<AppUser>(a => a.Receiver)
                .WithMany(m => m.Messages)
                .HasForeignKey(f => f.ReceiverID);
        }



        //Data initialization methods

        public void SeedData()
        {
            if (!Users.Any())
            {
                Users.AddRange(
                    new AppUser() { Id = "user1@gmail.com" },
                    new AppUser() { Id = "user2@gmail.com" },
                    new AppUser() { Id = "user3@gmail.com" },
                    new AppUser() { Id = "user4@gmail.com" });
                SaveChanges();

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
