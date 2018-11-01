using System;
using System.Collections.Generic;

namespace Barbershop.Feedback.DataAccessLayer
{
    public class FeedbackStorage : IFeedbackStorage
    {
        private readonly List<BarberFeedbackCollection> _feedbackCollection;

        public FeedbackStorage()
        {
            _feedbackCollection = new List<BarberFeedbackCollection>();
        }

        public void StoreFeedback(Feedback feedback)
        {
            var barberId = feedback.BarberId;
            var feedbackCollection = _feedbackCollection.Find(x => x.BarberId.Equals(barberId));
            if (feedbackCollection != null)
            {
                feedbackCollection.AddFeedback(feedback);
                return;
            }

            var newFeedbackCollection = new BarberFeedbackCollection(barberId);
            newFeedbackCollection.AddFeedback(feedback);
            _feedbackCollection.Add(newFeedbackCollection);
        }

        public BarberFeedbackCollection[] GetFeedbackCollections()
        {
            return _feedbackCollection.ToArray();
        }

        public BarberFeedbackCollection GetFeedbackCollection(Guid barberId)
        {
            var feedbackCollection = _feedbackCollection.Find(x => x.BarberId.Equals(barberId));
            return feedbackCollection;
        }
    }
}
