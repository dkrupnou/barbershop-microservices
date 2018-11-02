using System;

namespace Barbershop.Feedback.BusinessLayer
{
    public class BarberRatingStat
    {
        public Guid BarberId { get; set; }
        public int FeedbackCount { get; set; }
        public double AverageValue { get; set; }
    }
}
