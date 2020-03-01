using Olimpia.Mongo.Bankin.Domain.Events;
using Olimpia.Mongo.Domain.core.Bus;
using Olimpia.Mongo.Transfe.Domain.Interfaces;
using Olimpia.Mongo.Transfe.Domain.Models;
using System.Threading.Tasks;

namespace Olimpia.Mongo.Transfe.Domain.EventHandlers
{
    public class TransferEventHandler : IEventHandler<TransferCreatedEvent>
    {
        private readonly ITransferRepository _transferRepository;

        public TransferEventHandler(ITransferRepository transferRepository)
        {
            _transferRepository = transferRepository;
        }

        public Task Handle(TransferCreatedEvent @event)
        {
            _transferRepository.Add(new TransferLog()
            {
                FromAccount = @event.From,
                ToAccount = @event.To,
                TransferAmount = @event.Amount
            });

            return Task.CompletedTask;
        }
    }
}
