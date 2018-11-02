using System;
using Barbershop.Feedback.BusinessLayer.Util;
using Barbershop.Feedback.DataAccessLayer;

namespace Barbershop.Feedback.BusinessLayer
{
    public class FeedbackService : IFeedbackService
    {
        private readonly IFeedbackStorage _storage;

        public FeedbackService(IFeedbackStorage storage)
        {
            _storage = storage;
        }

        public BarberRatingStat GetBarberRatingStat(Guid barberId)
        {
            var feedbackCollection = _storage.GetFeedbackCollection(barberId);
            return feedbackCollection.ToBarberRatingStat();
        }

        public BarberFeedback[] GetBarberFeedback(Guid barberId)
        {
            var feedbackCollection = _storage.GetFeedbackCollection(barberId);
            return feedbackCollection.ToBarberFeedback();
        }

        public void StoreFeedback(Guid barberId, string body, double rating)
        {
            var feedback = new DataAccessLayer.Feedback(barberId, body, rating);
            _storage.StoreFeedback(feedback);
        }
    }
}
