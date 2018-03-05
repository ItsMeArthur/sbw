using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SBW.MVC.Data;
using SBW.MVC.Models;

namespace SBW.MVC
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // Register services for the applicaiton in order to leverage the DI from ASP.NET Core.
        public void ConfigureServices(IServiceCollection services)
        {
            // Configure EFCore in the startup.
            services.AddDbContext<AppDbContext>(options => options
                .UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            // Whenever a dependency is requested I deliver the instance of the proper object.
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<ISaleRepository, SaleRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();

            services.AddMvc();
        }

        // Where the configuration of middlewares take place. Should be used to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
