using System;

namespace Barbershop.Feedback.DataAccessLayer
{
    public class Feedback
    {
        public Guid Id { get; }
        public Guid BarberId { get; }
        public DateTime Timestamp { get; }
        public string Body { get; }
        public double Rating { get; }

        public Feedback(Guid barberId, string body, double rating)
        {
            Id = Guid.NewGuid();
            BarberId = barberId;
            Timestamp = DateTime.UtcNow;
            Body = body;
            Rating = rating;
        }
    }
}
