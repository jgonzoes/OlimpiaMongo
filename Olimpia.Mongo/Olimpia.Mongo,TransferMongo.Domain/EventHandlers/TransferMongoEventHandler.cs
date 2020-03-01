using Olimpia.Mongo.Domain.core.Bus;
using Olimpia.Mongo_TransferMongo.Domain.Events;
using Olimpia.Mongo_TransferMongo.Domain.Interfaces;
using Olimpia.Mongo_TransferMongo.Domain.Models;
using System.Threading.Tasks;

namespace Olimpia.Mongo_TransferMongo.Domain.EventHandlers
{
    public class TransferMongoEventHandler : IEventHandler<TransferMongoCreatedEvent>
    {
        private readonly ITransferMongoRepository _transferRepository;

        public TransferMongoEventHandler(ITransferMongoRepository transferRepository)
        {
            _transferRepository = transferRepository;
        }

        public Task Handle(TransferMongoCreatedEvent @event)
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
