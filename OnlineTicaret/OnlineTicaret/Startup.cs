using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OnlineTicaret.Data;
using OnlineTicaret.Data.Interfaces;
using OnlineTicaret.Data.Mocks;
using OnlineTicaret.Data.Models;
using OnlineTicaret.Data.Repository;

namespace OnlineTicaret
{
    public class Startup
    {

        private IConfigurationRoot _configurationRoot;
        public Startup(IHostingEnvironment hostingEnvironment)
        {
            _configurationRoot = new ConfigurationBuilder()
                .SetBasePath(hostingEnvironment.ContentRootPath)
                .AddJsonFile("appsettings.json")
                .Build();
        }
        public void ConfigureServices(IServiceCollection services)
        {
            //Service Configuration
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(_configurationRoot.GetConnectionString("DefaultConnection")));

            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>();



            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IFeedbackRepository, FeedbackRepocitory>();


            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped(sp => ShoppingCart.GetCart(sp));
            services.AddTransient<IOrderRepository, OrderRepository>();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = true;

                options.Password.RequireLowercase = true;

                options.Password.RequiredLength = 5;

                options.Password.RequireNonAlphanumeric = false;

                options.Password.RequireUppercase = false;
            });

            services.AddMvc();
            services.AddMemoryCache();
            services.AddSession();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory ,IServiceProvider serviceProvider)
        {
            loggerFactory.AddConsole();
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseSession();
            app.UseIdentity();
            //app.UseMvcWithDefaultRoute();
            app.UseMvc(routes =>
            {

                routes.MapRoute(
                  name: "areas",
                  template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                    
                
                routes.MapRoute(
                    name: "categoryfilter",
                    template: "Product/{action}/{category?}",
                    defaults: new { Controller = "Product", action = "List" });

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{Id?}");
            });

            DbInitiliazer.Seed(serviceProvider);

        }
    }
}
