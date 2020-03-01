using MongoDB.Driver;
using Olimpia.Mongo_TransferMongo.Domain.Interfaces;
using Olimpia.Mongo_TransferMongo.Domain.Models;
using System.Collections.Generic;
using Olimpia.Mongo.TransferMongo.Data.Context;

namespace Olimpia.Mongo.TransferMongo.Data.Repository
{
    public class TransferMongoRepository : ITransferMongoRepository
    {
        private readonly Context.Context _context;

        public TransferMongoRepository(Context.Context context)
        {
            _context = context;
        }

        private readonly IMongoCollection<TransferLog> _transferLog;

        public TransferMongoRepository(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _transferLog = database.GetCollection<TransferLog>(settings.LogsCollectionName);
        }

        public IEnumerable<TransferLog> GetTransferLogs() =>
            _transferLog.Find(transferlog => true).ToList();


        public TransferLog Add(TransferLog transferlog)
        {
            _transferLog.InsertOne(transferlog);
            return transferlog;
        }

        public void Remove(string id) =>
            _transferLog.DeleteOne(transferlog => transferlog.Id == id);

    }
}
