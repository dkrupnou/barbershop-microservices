using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Barbershop.MicroserviceBase.ServiceDiscovery
{
    public class ConsulHttpClient : IConsulHttpClient
    {
        private readonly HttpClient _client;

        public ConsulHttpClient(HttpClient client)
        {
            _client = client;
        }

        public async Task<T> GetAsync<T>(string requestUri)
        {
            var uri = requestUri.StartsWith("http://") ? requestUri : $"http://{requestUri}";
            var response = await _client.GetAsync(uri);
            if (!response.IsSuccessStatusCode)
                return default(T);

            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(content);
        }

        public async Task PostAsync<T>(string requestUri, T model)
        {
            var uri = requestUri.StartsWith("http://") ? requestUri : $"http://{requestUri}";
            var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = await _client.PostAsync(uri, content);
            response.EnsureSuccessStatusCode();
        }
    }
}
