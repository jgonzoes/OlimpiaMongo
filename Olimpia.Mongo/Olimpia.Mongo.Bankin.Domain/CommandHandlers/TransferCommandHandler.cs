using MediatR;
using Olimpia.Mongo.Bankin.Domain.Commands;
using Olimpia.Mongo.Bankin.Domain.Events;
using Olimpia.Mongo.Domain.core.Bus;
using System.Threading;
using System.Threading.Tasks;

namespace Olimpia.Mongo.Bankin.Domain.CommandHandlers
{
    public class TransferCommandHandler : IRequestHandler<CreateTransferCommand, bool>
    {
        private readonly IEventBus _bus;

        public TransferCommandHandler(IEventBus bus)
        {
            _bus = bus;
        }

        public Task<bool> Handle(CreateTransferCommand request, CancellationToken cancellationToken)
        {
            //public event to RabbitMQ
            _bus.Publish(new TransferCreatedEvent(request.From, request.To, request.Amount));

            return Task.FromResult(true);
        }
    }
}
