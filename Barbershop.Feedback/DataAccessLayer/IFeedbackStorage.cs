using System;

namespace Barbershop.Feedback.DataAccessLayer
{
    public interface IFeedbackStorage
    {
        void StoreFeedback(Feedback feedback);

        BarberFeedbackCollection[] GetFeedbackCollections();

        BarberFeedbackCollection GetFeedbackCollection(Guid barberId);
    }
}
