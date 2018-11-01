using System;
using System.Collections.Generic;
using System.Linq;

namespace Barbershop.Feedback.DataAccessLayer
{
    public class BarberFeedbackCollection
    {
        public Guid BarberId { get; private set; }
        public double AverageRating { get; private set; }
        public Feedback[] FeedbackList => _feedbackList.ToArray();

        private readonly List<Feedback> _feedbackList;

        public BarberFeedbackCollection(Guid barberId)
        {
            BarberId = barberId;
            AverageRating = 0;
            _feedbackList = new List<Feedback>();
        }

        public void AddFeedback(Feedback feedback)
        {
            _feedbackList.Add(feedback);
            RecalculateAverageRating();
        }

        private void RecalculateAverageRating()
        {
            var feedbackCount = _feedbackList.Count;
            var ratingSum = _feedbackList.Sum(x => x.Rating);
            AverageRating = ratingSum / feedbackCount;
        }
    }
}
