using Olimpia.Mongo.Domain.core.Bus;
using Olimpia.Mongo.TransferMongo.Aplication.Interfaces;
using Olimpia.Mongo_TransferMongo.Domain.Interfaces;
using Olimpia.Mongo_TransferMongo.Domain.Models;
using System.Collections.Generic;

namespace Olimpia.Mongo.TransferMongo.Aplication.Services
{
    public class TransferService : ITransferService
    {
        private readonly ITransferRepository _transferRepository;
        private readonly IEventBus _bus;

        public TransferService(ITransferRepository transferRepository, IEventBus bus)
        {
            _transferRepository = transferRepository;
            _bus = bus;
        }
        public IEnumerable<TransferLog> GetTransferLogs()
        {
            return _transferRepository.GetTransferLogs();
        }
    }
}
