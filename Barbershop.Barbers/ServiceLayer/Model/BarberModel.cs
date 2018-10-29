using Newtonsoft.Json;

namespace Barbershop.Barbers.ServiceLayer.Model
{
    public class BarberModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }
    }
}
