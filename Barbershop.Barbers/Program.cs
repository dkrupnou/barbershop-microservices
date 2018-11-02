using Barbershop.MicroserviceBase.Healthcheck;
using Barbershop.MicroserviceBase.Logging;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace Barbershop.Barbers
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseLogging()
                .UseHealthcheckEndpoint();
    }
}
