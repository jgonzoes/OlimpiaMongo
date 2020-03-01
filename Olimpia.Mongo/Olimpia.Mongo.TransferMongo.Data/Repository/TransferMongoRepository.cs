
using MongoDB.Driver;
using Olimpia.Mongo_TransferMongo.Domain.Interfaces;
using Olimpia.Mongo_TransferMongo.Domain.Models;
using System.Collections.Generic;

namespace Olimpia.Mongo.TransferMongo.Data.Repository
{
    public class TransferMongoRepository 
    {
        private readonly IMongoCollection<TransferLog> _transferLog;

        public TransferMongoRepository(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _transferLog = database.GetCollection<TransferLog>(settings.transferlogsCollectionName);
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
