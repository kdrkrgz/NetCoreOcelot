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
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

namespace OcelotGateway
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
            // Ocelot
            services.AddOcelot();
            services.AddSwaggerForOcelot(Configuration);
 
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public async void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            // sources : 
            // https://medium.com/swlh/building-net-core-api-gateway-with-ocelot-6302c2b3ffc5
            // https://feyyazacet.medium.com/net-core-api-gateway-asp-net-core-3-1-ocelot-19fb27585287
            // https://medium.com/devopsturkiye/net-core-microservice-api-gateway-9c28f988bc52


            app.UseRouting();

            app.UseAuthorization();

            // app.UseSwaggerForOcelotUI(opt => {
            //       opt.PathToSwaggerGenerator = "/swagger/docs";
            // });


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwaggerForOcelotUI(opt => {
                  opt.PathToSwaggerGenerator = "/swagger/docs";
            });

            // app.UseOcelot().Wait(); // waitable or await like after this
            await app.UseOcelot();       

        }
    }
}
