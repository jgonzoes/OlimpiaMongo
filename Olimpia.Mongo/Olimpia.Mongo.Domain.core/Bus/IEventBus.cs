using Olimpia.Mongo.Domain.core.Commands;
using Olimpia.Mongo.Domain.core.Events;
using System.Threading.Tasks;

namespace Olimpia.Mongo.Domain.core.Bus
{
    public interface IEventBus
    {
        Task SendCommand<T>(T command) where T : Command;

        void Publish<T>(T @event) where T : Event;

        void Subscribe<T, TH>() where T : Event where TH : IEventHandler<T>;
    }
}
