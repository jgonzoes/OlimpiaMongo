namespace Olimpia.Mongo_TransferMongo.Domain.Interfaces
{
    public interface IDatabaseSettings
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
        string LogsCollectionName { get; set; }
    }
}
