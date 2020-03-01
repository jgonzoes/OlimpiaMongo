using Olimpia.Mongo_TransferMongo.Domain.Models;
using System.Collections.Generic;

namespace Olimpia.Mongo_TransferMongo.Domain.Interfaces
{
    public interface ITransferRepository
    {
        IEnumerable<TransferLog> GetTransferLogs();

        void Add(TransferLog transferLog);

        void Remove(string id);
    }
}
