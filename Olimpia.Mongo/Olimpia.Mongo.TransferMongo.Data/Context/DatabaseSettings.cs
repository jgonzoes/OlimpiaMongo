using Autofac;
using Olimpia.Mongo_TransferMongo.Domain.Interfaces;
using Olimpia.Mongo.Rabbit.Infra.IoC;

namespace Olimpia.Mongo.TransferMongo.Data.Context
{
    public  class DatabaseSettings : IDatabaseSettings
    {
        public string BooksCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }

        protected DatabaseSettings(ContainerBuilder builder)
        {
            builder.RegisterType<Context>()
                .As<Context>()
                .WithParameter("connectionString", ConnectionString)
                .WithParameter("databaseName", DatabaseName)
                .SingleInstance();

            //
            // Register all Types in MongoDataAccess namespace
            //
            builder.RegisterAssemblyTypes(typeof(InfrastructureException).Assembly)
                .Where(type => type.Namespace.Contains("MongoDataAccess"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}
