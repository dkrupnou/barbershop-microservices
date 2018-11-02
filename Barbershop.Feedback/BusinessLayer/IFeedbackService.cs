using System;

namespace Barbershop.Feedback.BusinessLayer
{
    public interface IFeedbackService
    {
        BarberRatingStat GetBarberRatingStat(Guid barberId);

        BarberFeedback[] GetBarberFeedback(Guid barberId);

        void StoreFeedback(Guid barberId, string body, double rating);
    }
}