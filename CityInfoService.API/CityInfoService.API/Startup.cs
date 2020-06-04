using CityInfoService.API.DataAccess;
using CityInfoService.API.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CityInfoService.API
{
    public class Startup
    {
        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<CityInfoContext>(options => 
                    options.UseSqlServer(this.configuration.GetConnectionString("DefaultConnection")));

            services.AddMvc();
            services.AddTransient<ICitiesInfoService, CitiesInfoService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //  Just to test the pipeline and if the controller's routing

            //app.run(async (context) =>
            //{
            //    await context.response.writeasync("hello world!");
            //});

            app.UseMvc();
        }
    }
}
