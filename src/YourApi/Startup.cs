using System.Linq;
using System.Text.Json;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using YourApi.Infrastructure.Data;

namespace YourApi
{
    public class Startup
    {
		public static void Main(string[] args)
        => Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>()
							  .UseUrls("http://*:80");
                }).Build()
				  .Run();

        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
		{
            Configuration = configuration;
		}

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRouting();

            var defaultDatabase = Configuration.GetConnectionString("DefaultDatabase") 
                ?? System.Environment.GetEnvironmentVariable("ConnectionStrings__DefaultDatabase");

            if (string.IsNullOrEmpty(defaultDatabase)){
                System.Console.WriteLine("Critical-> No database configured");
            }
            else 
            {
    			services.AddDbContext<TestDatabaseContext>(options =>
	    			options.UseSqlServer(defaultDatabase));
            }
            
            services.AddTransient<TestDatabaseContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/api/hello", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });

                endpoints.MapGet("/api/categories", async context =>
                {
                    var dbContext = context.RequestServices.GetService<TestDatabaseContext>();

                    var result = JsonSerializer.Serialize(dbContext.ProductCategory.ToArray());

                    context.Response.ContentType = "application/json";
                    await context.Response.WriteAsync(result);
                });
            });
        }
    }
}
