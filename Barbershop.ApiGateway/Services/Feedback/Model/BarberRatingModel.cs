using Newtonsoft.Json;

namespace Barbershop.ApiGateway.Services.Feedback.Model
{
    public class BarberRatingModel
    {
        [JsonProperty("barberId")]
        public string BarberId { get; set; }

        [JsonProperty("rating")]
        public double Rating { get; set; }
    }
}
