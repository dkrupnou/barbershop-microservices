using System.Threading.Tasks;

namespace Barbershop.MicroserviceBase.Messaging
{
    public interface ICommandHandler<in TCommand> where TCommand : ICommand
    {
        Task HandleAsync(TCommand command);
    }
}