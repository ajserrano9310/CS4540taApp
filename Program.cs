using PS4_TAApplication.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using PS4_TAApplication.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;

namespace PS4_TAApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            CreateDbIfNotExists(host);

            using (var scope = host.Services.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;
                try
                {
                    var services = scope.ServiceProvider;
                    var context = services.GetRequiredService<TAUsersRolesDB>();
                    var userManager = serviceProvider.GetRequiredService<UserManager<TAUser>>();
                    var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                    SeedUsersRolesDB.Seed(userManager, roleManager, context).Wait();
                }
                catch (Exception ex)
                {
                    var logger = serviceProvider.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred creating the DB for users and roles.");
                }
            }

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var c_context = services.GetRequiredService<Course_DB>();
                    Course_DB_init.Initialize(c_context);


                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred creating the DB.");
                }
            }

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var avail_context = services.GetRequiredService<Avail_DB>();
                    AvailInit.Initialize(avail_context);


                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred creating the availability DB.");
                }
            }

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var avail_context = services.GetRequiredService<CourseEnrollContext>();
                    ChartInit.Initialize(avail_context);


                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred creating the availability DB.");
                }
            }

            host.Run();
        }

        private static void CreateDbIfNotExists(IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<TA_DB>();
                    TA_DB_Initializer.Initialize(context);
                    
                    
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred creating the DB.");
                }
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
