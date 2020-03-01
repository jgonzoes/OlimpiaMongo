using Olimpia.Mongo.Domain.core.Bus;
using Olimpia.Mongo.Transfe.Domain.Interfaces;
using Olimpia.Mongo.Transfe.Domain.Models;
using Olimpia.Mongo.Transfer.Aplication.Interfaces;
using System.Collections.Generic;

namespace Olimpia.Mongo.Transfer.Aplication.Services
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
