using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;


namespace ProductApi
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

            services.AddSwaggerGen(s => {
                s.SwaggerDoc("ProductSwagger", new Microsoft.OpenApi.Models.OpenApiInfo{
                    Version = "1.0.0",
                    Title = ".Net Core Web Api With Swagger",
                    Description = ".Net Core Web Api With Swagger",
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact(){
                        Name = "Product Api Support",
                        Email = "kadir@kadirkaragoz.com",
                        Url = new Uri("https://kadirkaragoz.com")
                    },
                    TermsOfService = new Uri("http://example.com/terms/")
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseDeveloperExceptionPage();

            //app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerUI(s => {
                s.SwaggerEndpoint("/swagger/ProductSwagger/swagger.json", "Swagger With Ocelot");
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
