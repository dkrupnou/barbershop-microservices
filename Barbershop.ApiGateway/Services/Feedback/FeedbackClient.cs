using System;
using System.Threading.Tasks;
using Barbershop.ApiGateway.Services.Feedback.Model;
using Barbershop.MicroserviceBase.ServiceDiscovery;

namespace Barbershop.ApiGateway.Services.Feedback
{
    public class FeedbackClient : IFeedbackClient
    {
        private readonly IConsulHttpClient _consulHttpClient;

        private static string FeedbackServiceEndpoint = "feedback";
        private static string RatingPath = "api/rating";
        private static string FeedbackPath = "api/feedback";

        public FeedbackClient(IConsulHttpClient consulHttpClient)
        {
            _consulHttpClient = consulHttpClient;
        }

        public async Task<BarberRatingModel> GetBarberRating(Guid barberId)
        {
            var url = string.Format("{0}/{1}/{2}", FeedbackServiceEndpoint, RatingPath, barberId);
            return await _consulHttpClient.GetAsync<BarberRatingModel>(url);
        }

        public async Task<BarberRatingModel[]> GetBarbersRating()
        {
            var url = string.Format("{0}/{1}", FeedbackServiceEndpoint, RatingPath);
            return await _consulHttpClient.GetAsync<BarberRatingModel[]>(url);
        }

        public async Task<BarberFeedbackModel[]> GetBarberFeedback(Guid barberId)
        {
            var url = string.Format("{0}/{1}/{2}", FeedbackServiceEndpoint, FeedbackPath, barberId);
            return await _consulHttpClient.GetAsync<BarberFeedbackModel[]>(url);
        }

        public async Task PostBarberFeedback(BarberFeedbackEvaluationModel feedback)
        {
            var url = string.Format("{0}/{1}", FeedbackServiceEndpoint, FeedbackPath);
            await _consulHttpClient.PostAsync(url, feedback);
        }
    }
}
