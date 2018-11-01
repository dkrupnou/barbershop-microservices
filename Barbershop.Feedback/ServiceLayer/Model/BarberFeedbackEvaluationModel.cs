using Newtonsoft.Json;

namespace Barbershop.Feedback.ServiceLayer.Model
{
    public class BarberFeedbackEvaluationModel
    {
        [JsonProperty("barberId")]
        public string BarberId { get; set; }

        [JsonProperty("body")]
        public string Body { get; set; }

        [JsonProperty("rating")]
        public double Rating { get; set; }
    }
}
