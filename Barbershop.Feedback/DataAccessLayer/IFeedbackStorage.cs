using System;

namespace Barbershop.Feedback.DataAccessLayer
{
    public interface IFeedbackStorage
    {
        void StoreFeedback(Feedback feedback);

        BarberFeedbackCollection GetFeedbackCollection(Guid barberId);
    }
}
