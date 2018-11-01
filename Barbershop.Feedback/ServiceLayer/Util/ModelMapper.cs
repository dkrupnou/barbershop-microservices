using Barbershop.Feedback.BusinessLayer;
using Barbershop.Feedback.ServiceLayer.Model;

namespace Barbershop.Feedback.ServiceLayer.Util
{
    public static class ModelMapper
    {
        public static BarberRatingModel ToBarberRatingModel(this BarberRating rating)
        {
            return new BarberRatingModel()
            {
                BarberId = rating.Id.ToString("N"),
                Rating = rating.AverageValue
            };
        }

        public static BarberFeedbackModel ToBarberFeedbackModel(this BarberFeedback feedback)
        {
            return new BarberFeedbackModel()
            {
                Timestamp = feedback.Timestamp,
                Body = feedback.Body,
                Rating = feedback.Rating
            };
        }
    }
}
