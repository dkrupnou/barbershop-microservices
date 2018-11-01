using Barbershop.Feedback.BusinessLayer;
using Barbershop.Feedback.DataAccessLayer;
using Barbershop.MicroserviceBase.ApiDocumentation;
using Barbershop.MicroserviceBase.Healthcheck;
using Barbershop.MicroserviceBase.ServiceDiscovery;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Barbershop.Feedback
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
            services.AddSingleton<IFeedbackStorage, FeedbackStorage>();
            services.AddTransient<IFeedbackService, FeedbackService>();

            services.AddConsul();
            services.AddSwagger();
            services.AddBasicHttpHealthCheck();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseConsul();
            app.UseSwagger();

            app.UseMvc();
        }
    }
}
