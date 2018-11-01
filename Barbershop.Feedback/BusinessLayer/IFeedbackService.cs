using System;

namespace Barbershop.Feedback.BusinessLayer
{
    public interface IFeedbackService
    {
        BarberRating[] GetBarberRatings();

        BarberRating GetBarberRating(Guid barberId);

        BarberFeedback[] GetBarberFeedback(Guid barberId);

        void PostBarberFeedback(Guid barberId, string body, double rating);
    }
}