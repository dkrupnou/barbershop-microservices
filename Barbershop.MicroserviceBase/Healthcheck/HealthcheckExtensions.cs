using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.HealthChecks;

namespace Barbershop.MicroserviceBase.Healthcheck
{
    public static class HealthcheckExtensions
    {
        public static IWebHostBuilder UseHealthcheckEndpoint(this IWebHostBuilder webHostBuilder)
        {
            webHostBuilder.UseHealthChecks("/healthcheck");
            return webHostBuilder;
        }

        public static IServiceCollection AddBasicHttpHealthCheck(this IServiceCollection services)
        {
            services.AddHealthChecks(checks =>
            {
                checks.AddValueTaskCheck("HTTP Endpoint", () => new ValueTask<IHealthCheckResult>(HealthCheckResult.Healthy("Ok")));
            });
            return services;
        }
    }
}
