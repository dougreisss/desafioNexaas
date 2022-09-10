using Application.Application;
using Application.Interface;
using Domain.Interface;
using Domain.Interface.Service;
using Domain.Service;
using Infrastructure.Config;
using Infrastructure.Config.Interface;
using Infrastructure.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApi", Version = "v1" });
            });

            //application
            services.AddSingleton<IProductApplication, ProductApplication>();
            services.AddSingleton<IStoreApplication, StoreApplication>();
            services.AddSingleton<IStockItemApplication, StockItemApplication>();

            //domain
            services.AddSingleton<IProductService, ProductService>();
            services.AddSingleton<IStoreService, StoreService>();
            services.AddSingleton<IStockItemService, StockItemService>();

            // repository
            services.AddSingleton<IProduct, ProductRepository>();
            services.AddSingleton<IStore, StoreRepository>();
            services.AddSingleton<IStockItem, StockItemRepository>();

            //helper
            services.AddSingleton<IDbConfig, DbConfig>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
