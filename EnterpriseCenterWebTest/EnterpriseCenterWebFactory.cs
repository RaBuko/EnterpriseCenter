using EnterpriseCenterWeb.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EnterpriseCenterWebIntegrationTests
{
    public class EnterpriseCenterWebFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup: class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<EnterpriseCenterContext>));

                services.Remove(descriptor);

                services.AddDbContext<EnterpriseCenterContext>(options =>
                {
                    options.UseInMemoryDatabase("InMemoryDbForTesting");
                });

                var sp = services.BuildServiceProvider();

                using (var scope = sp.CreateScope())
                {
                    var scopedServices = scope.ServiceProvider;
                    var db = scopedServices.GetRequiredService<EnterpriseCenterContext>();
                    var logger = scopedServices.GetRequiredService<ILogger<EnterpriseCenterWebFactory<TStartup>>>();

                    db.Database.EnsureCreated();

                    try
                    {
                        InitDb.InitializeDbForTests(db);
                    }
                    catch (Exception ex)
                    {
                        logger.LogError(ex, "Error setting up WebHost. Error: {Message}", ex.Message);
                    }
                }
            });
        }
    }
}
