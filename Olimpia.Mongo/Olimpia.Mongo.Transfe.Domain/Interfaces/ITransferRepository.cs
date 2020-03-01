using Olimpia.Mongo.Transfe.Domain.Models;
using System.Collections.Generic;

namespace Olimpia.Mongo.Transfe.Domain.Interfaces
{
    public interface ITransferRepository
    {
        IEnumerable<TransferLog> GetTransferLogs();

        void Add(TransferLog transferLog);
    }
}
