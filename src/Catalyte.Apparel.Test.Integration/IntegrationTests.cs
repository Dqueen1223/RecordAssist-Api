using Catalyte.SuperHealth.API;
using Catalyte.SuperHealth.Data.Context;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Net.Http;

namespace Catalyte.SuperHealth.Test.Integration
{
    public abstract class IntegrationTests
    {
        protected readonly HttpClient _client;
        protected readonly WebApplicationFactory<Startup> _factory;

        protected IntegrationTests()
        {
            _factory = new WebApplicationFactory<Startup>()
                .WithWebHostBuilder(builder =>
                {
                    builder.ConfigureServices(services =>
                    {
                        services.RemoveAll(typeof(SuperHealthCtx));
                        services.AddDbContext<SuperHealthCtx>((options, context) =>
                        {
                            context.UseNpgsql("Host=localhost; Port=5432; Database=postgres_tests; UserName=postgres; Password=root");
                        });

                        var serviceProvider = services.BuildServiceProvider();

                        using (var scope = serviceProvider.CreateScope())
                        {
                            var scopedServices = scope.ServiceProvider;
                            var context = scopedServices.GetRequiredService<SuperHealthCtx>();
                            var logger = scopedServices.GetRequiredService<ILogger<WebApplicationFactory<Startup>>>();

                            context.Database.EnsureCreated();

                        }
                    });
                    builder.UseContentRoot(Directory.GetCurrentDirectory());
                });
            _client = _factory.CreateClient();
        }
    }
}