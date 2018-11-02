using Newtonsoft.Json;

namespace Barbershop.Feedback.ServiceLayer.Model
{
    public class BarberRatingStatModel
    {
        [JsonProperty("barberId")]
        public string BarberId { get; set; }

        [JsonProperty("rating")]
        public double Rating { get; set; }

        [JsonProperty("feedbackCount")]
        public int FeedbackCount { get; set; }
    }
}
