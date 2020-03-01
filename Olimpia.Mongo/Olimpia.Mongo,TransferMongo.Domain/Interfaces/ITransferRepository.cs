using Olimpia.Mongo_TransferMongo.Domain.Models;
using System.Collections.Generic;

namespace Olimpia.Mongo_TransferMongo.Domain.Interfaces
{
    public interface ITransferMongoRepository
    {
        IEnumerable<TransferLog> GetTransferLogs();

        TransferLog Add(TransferLog transferlog);
        void Remove(string id);
    }
}
