using Olimpia.Mongo.Transfe.Domain.Models;
using System.Collections.Generic;

namespace Olimpia.Mongo.Transfer.Aplication.Interfaces
{
    public interface ITransferService
    {
        IEnumerable<TransferLog> GetTransferLogs();
    }
}
