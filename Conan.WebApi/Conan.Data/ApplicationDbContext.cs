using System;
using System.Collections.Generic;
using System.Text;
using Conan.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Conan.Data
{
    public class ApplicationDbContext : IdentityDbContext
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
    }
}
