﻿using System.Threading.Tasks;

namespace Barbershop.MicroserviceBase.ServiceDiscovery
{
    public interface IConsulHttpClient
    {
        Task<T> GetAsync<T>(string requestUri);

        Task PostAsync<T>(string requestUri, T model);
    }
}
