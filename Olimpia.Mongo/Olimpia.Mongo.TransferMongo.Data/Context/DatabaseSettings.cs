using Autofac;
using Olimpia.Mongo_TransferMongo.Domain.Interfaces;

namespace Olimpia.Mongo.TransferMongo.Data.Context
{
    public  class DatabaseSettings : IDatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string LogsCollectionName { get; set; }

        protected DatabaseSettings(ContainerBuilder builder)
        {
            builder.RegisterType<Context>()
                .As<Context>()
                .WithParameter("connectionString", ConnectionString)
                .WithParameter("databaseName", DatabaseName)
                .WithParameter("logsCollectionName", LogsCollectionName)
                .SingleInstance();
        }
    }
}
