using System;
using FoodOrdering.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using FoodOrdering._context;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Common;
using Swashbuckle.AspNetCore.Swagger;
using Cafe.Repositories;
using System.Text.Json.Serialization;
namespace FoodOrdering
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
            //services.AddControllers.AddJsonOptions(options => { options.JsonSerializerOptions.});
            services.AddControllers();
            services.AddDbContext<DBContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddTransient<ICustomerRepo, CustomerRepo>();
            services.AddTransient<IMenuRepo, MenuRepo>();
            services.AddScoped<IFeedbackRepo, FeedbackRepo>();
            services.AddScoped<IOrdersRepo, OrdersRepo>();

            services.AddCors();

            services.AddSwaggerGen();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                { 
                    Version = "v1",
                    Title = "Implementation swagger UI",
                    Description = "Simple demo for Implement swagger UI",

                });
            });
        }
            // services.AddSwaggerGen();

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(x => x
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .SetIsOriginAllowed(origin => true)
                    .AllowCredentials());
            app.UseStaticFiles();
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            app.UseSwaggerUI();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "showing API v1");
            }
            );
            

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
