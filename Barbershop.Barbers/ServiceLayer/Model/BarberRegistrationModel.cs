using Newtonsoft.Json;

namespace Barbershop.Barbers.ServiceLayer.Model
{
    public class BarberRegistrationModel
    {
        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }
    }
}
