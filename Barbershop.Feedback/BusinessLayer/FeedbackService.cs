using System;
using System.Linq;
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

        public BarberRating[] GetBarberRatings()
        {
            var feedbackCollections = _storage.GetFeedbackCollections();
            return feedbackCollections.Select(x => x.ToBarberRating()).ToArray();
        }

        public BarberRating GetBarberRating(Guid barberId)
        {
            var feedbackCollection = _storage.GetFeedbackCollection(barberId);
            return feedbackCollection.ToBarberRating();
        }

        public BarberFeedback[] GetBarberFeedback(Guid barberId)
        {
            var feedbackCollection = _storage.GetFeedbackCollection(barberId);
            return feedbackCollection.ToBarberFeedback();
        }

        public void PostBarberFeedback(Guid barberId, string body, double rating)
        {
            var feedback = new DataAccessLayer.Feedback(barberId, body, rating);
            _storage.StoreFeedback(feedback);
        }
    }
}
