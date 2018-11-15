using MasterDance.Web;
using MasterDance.Web.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MasterDance.IntegrationTests
{
    public class CustomWebApplicationFactory : WebApplicationFactory<Startup>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var serviceProvider = new ServiceCollection()
                    .AddEntityFrameworkInMemoryDatabase()
                    .BuildServiceProvider();

                services.AddDbContext<MasterDanceContext>(opts =>
                {
                    opts.UseInMemoryDatabase("MasterDance_IntegrationTests");
                    opts.UseInternalServiceProvider(serviceProvider);
                });
                var sp = services.BuildServiceProvider();
                using (var scope = sp.CreateScope())
                {
                    var scopedService = scope.ServiceProvider;
                    var ctx = scopedService.GetRequiredService<MasterDanceContext>();
                    DbInitializer.InitializeDatabase(ctx);
                }
            });
        }
    }
}