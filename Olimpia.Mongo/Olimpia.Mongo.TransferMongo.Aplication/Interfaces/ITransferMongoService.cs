using Olimpia.Mongo_TransferMongo.Domain.Models;
using System.Collections.Generic;

namespace Olimpia.Mongo.TransferMongo.Aplication.Interfaces
{
    public interface ITransferMongoService
    {
        IEnumerable<TransferLog> GetTransferLogs();
    }
}
