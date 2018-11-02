using System.Linq;
using Barbershop.Feedback.DataAccessLayer;

namespace Barbershop.Feedback.BusinessLayer.Util
{
    public static class ModelMapper
    {
        public static BarberRatingStat ToBarberRatingStat(this BarberFeedbackCollection collection)
        {
            if (collection == null)
                return null;

            return new BarberRatingStat()
            {
                BarberId = collection.BarberId,
                AverageValue = collection.AverageRating,
                FeedbackCount = collection.FeedbackList.Length
            };
        }

        public static BarberFeedback[] ToBarberFeedback(this BarberFeedbackCollection collection)
        {
            if (collection == null)
                return null;

            return collection.FeedbackList?.Select(x => new BarberFeedback()
            {
                Timestamp = x.Timestamp,
                Rating = x.Rating,
                Body = x.Body
            }).ToArray();
        }
    }
}
