using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using Olimpia.Mongo_TransferMongo.Domain.Models;

namespace Olimpia.Mongo.TransferMongo.Data.Context
{
    public class Context
    {
        private readonly MongoClient mongoClient;
        private readonly IMongoDatabase database;

        public Context(string connectionString, string databaseName)
        {
            this.mongoClient = new MongoClient(connectionString);
            this.database = mongoClient.GetDatabase(databaseName);
            Map();
        }

        public IMongoCollection<TransferLog> Customers
        {
            get
            {
                return database.GetCollection<TransferLog>("TransferLog");
            }
        }

        private void Map()
        {
            BsonClassMap.RegisterClassMap<TransferLog>(cm =>
            {
                cm.AutoMap();
            });
        }
    }
}
