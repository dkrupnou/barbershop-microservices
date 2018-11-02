using Barbershop.Feedback.BusinessLayer;
using Barbershop.Feedback.ServiceLayer.Model;

namespace Barbershop.Feedback.ServiceLayer.Util
{
    public static class ModelMapper
    {
        public static BarberRatingStatModel ToBarberRatingModel(this BarberRatingStat rating)
        {
            return new BarberRatingStatModel()
            {
                BarberId = rating.BarberId.ToString("N"),
                Rating = rating.AverageValue,
                FeedbackCount = rating.FeedbackCount
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
