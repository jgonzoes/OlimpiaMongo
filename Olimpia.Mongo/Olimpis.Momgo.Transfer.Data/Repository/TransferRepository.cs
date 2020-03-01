using Olimpia.Mongo.Transfe.Domain.Interfaces;
using Olimpia.Mongo.Transfe.Domain.Models;
using Olimpis.Momgo.Transfer.Data.Context;
using System.Collections.Generic;

namespace Olimpis.Momgo.Transfer.Data.Repository
{
    public class TransferRepository : ITransferRepository
    {
        private TransferDbContext _ctx;

        public TransferRepository(TransferDbContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<TransferLog> GetTransferLogs()
        {
            return _ctx.TransferLogs;
        }

        public void Add(TransferLog transferLog)
        {
            _ctx.TransferLogs.Add(transferLog);
            _ctx.SaveChanges();
        }
    }
}
