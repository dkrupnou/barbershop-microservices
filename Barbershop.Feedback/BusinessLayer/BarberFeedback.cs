using System;

namespace Barbershop.Feedback.BusinessLayer
{
    public class BarberFeedback
    {
        public DateTime Timestamp { get; set; }
        public string Body { get; set; }
        public double Rating { get; set; }
    }
}
