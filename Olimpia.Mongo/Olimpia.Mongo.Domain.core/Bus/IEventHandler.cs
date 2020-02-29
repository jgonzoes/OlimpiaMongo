using Olimpia.Mongo.Domain.core.Events;
using System.Threading.Tasks;

namespace Olimpia.Mongo.Domain.core.Bus
{
    public interface IEventHandler<in TEvent> : IEventHandler where TEvent : Event
    {
        Task Handle(TEvent @event);
    }

    public interface IEventHandler
    {

    }
}
