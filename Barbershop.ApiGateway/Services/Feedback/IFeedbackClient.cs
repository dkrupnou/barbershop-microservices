using System;
using System.Threading.Tasks;
using Barbershop.ApiGateway.Services.Feedback.Model;

namespace Barbershop.ApiGateway.Services.Feedback
{
    public interface IFeedbackClient
    {
        Task<BarberRatingModel> GetBarberRating(Guid barberId);
        Task<BarberRatingModel[]> GetBarbersRating();
        Task<BarberFeedbackModel[]> GetBarberFeedback(Guid barberId);
        Task PostBarberFeedback(BarberFeedbackEvaluationModel feedback);
    }
}