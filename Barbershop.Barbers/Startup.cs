using Barbershop.Barbers.BusinessLayer;
using Barbershop.Barbers.DataAccessLayer;
using Barbershop.MicroserviceBase.ApiDocumentation;
using Barbershop.MicroserviceBase.Healthcheck;
using Barbershop.MicroserviceBase.ServiceDiscovery;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Barbershop.Barbers
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IBarberDetailsStorage, BarberDetailsStorage>();
            services.AddTransient<IBarbersService, BarbersService>();

            services.AddConsul();
            services.AddSwagger();
            services.AddBasicHttpHealthCheck();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseConsul();
            app.UseSwagger();

            app.UseMvc();
        }
    }
}
