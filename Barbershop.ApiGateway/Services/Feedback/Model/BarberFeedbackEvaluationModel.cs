﻿using System;
using Newtonsoft.Json;

namespace Barbershop.ApiGateway.Services.Feedback.Model
{
    public class BarberFeedbackEvaluationModel
    {
        [JsonProperty("barberId")]
        public Guid BarberId { get; set; }

        [JsonProperty("body")]
        public string Body { get; set; }

        [JsonProperty("rating")]
        public double Rating { get; set; }
    }
}
