using System.Threading.Tasks;
using Consul;

namespace Barbershop.MicroserviceBase.ServiceDiscovery
{
    public interface IConsulServicesRegistry
    {
        Task<AgentService> GetAsync(string serviceName);
    }
}
