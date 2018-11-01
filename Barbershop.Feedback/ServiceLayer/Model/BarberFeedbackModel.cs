using System;
using Newtonsoft.Json;

namespace Barbershop.Feedback.ServiceLayer.Model
{
    public class BarberFeedbackModel
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("body")]
        public string Body { get; set; }

        [JsonProperty("rating")]
        public double Rating { get; set; }
    }
}
