using System.Threading.Tasks;

namespace Barbershop.MicroserviceBase.Messaging
{
    public interface IEventHandler<in TEvent> where TEvent : IEvent
    {
        Task HandleAsync(TEvent @event);
    }
}