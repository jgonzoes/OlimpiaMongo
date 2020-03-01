using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Olimpia.Mongo_TransferMongo.Domain.Models
{
    public class TransferLog
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public int FromAccount { get; set; }
        public int ToAccount { get; set; }
        public decimal TransferAmount { get; set; }
    }
}
