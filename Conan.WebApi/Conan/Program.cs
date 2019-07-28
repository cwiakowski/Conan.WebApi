using System;
using Conan.Data;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Conan.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetService<ApplicationDbContext>();
                var roleManager = services.GetService<RoleManager<IdentityRole>>();
                try
                {
                    context.Database.Migrate();
                    context.SeedDataAsync().Wait();
                    context.SeedRolesAsync(roleManager).Wait();
                }
                catch (Exception ex)
                {
                    // Error handling
                }
            }

            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
