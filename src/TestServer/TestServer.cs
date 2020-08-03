using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Mvc.Testing;

namespace Tests
{
    public class TestBase
    {
        public TestServer CreateServer()
        {
            var path = Assembly.GetAssembly(typeof(TestBase))
              .Location;

            var hostBuilder = new WebHostBuilder()
                .UseContentRoot(Path.GetDirectoryName(path))
                .ConfigureAppConfiguration(cb =>
                {
                    cb.AddJsonFile("appsettings.json", optional: false)
                    .AddEnvironmentVariables();
                })
                .UseStartup<YourApi.Startup>();


            var testServer = new TestServer(hostBuilder);

            /*
            testServer.Host
                .MigrateDbContext<YourDbContext>((context, services) =>
                {
                    var env = services.GetService<IWebHostEnvironment>();
                    var settings = services.GetService<IOptions<YourContext>>();
                    var logger = services.GetService<ILogger<YourContext>>();

                    new CatalogContextSeed()
                    .SeedAsync(context, env, settings, logger)
                    .Wait();
                })
                .MigrateDbContext<YourDbContext>((_, __) => { });
            */

            return testServer;
        }
    }
}