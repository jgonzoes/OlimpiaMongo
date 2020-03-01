using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Olimpia.Mongo.Bankin.Aplication.Interfaces;
using Olimpia.Mongo.Bankin.Aplication.Services;
using Olimpia.Mongo.Bankin.Data.Context;
using Olimpia.Mongo.Bankin.Data.Repository;
using Olimpia.Mongo.Bankin.Domain.CommandHandlers;
using Olimpia.Mongo.Bankin.Domain.Commands;
using Olimpia.Mongo.Bankin.Domain.Events;
using Olimpia.Mongo.Bankin.Domain.Interfaces;
using Olimpia.Mongo.Domain.core.Bus;
using Olimpia.Mongo.Rabbit.Infra.Bus;
using Olimpia.Mongo.Transfe.Domain.EventHandlers;
using Olimpia.Mongo.Transfe.Domain.Interfaces;
using Olimpia.Mongo.Transfer.Aplication.Interfaces;
using Olimpia.Mongo.Transfer.Aplication.Services;
using Olimpia.Mongo.TransferMongo.Aplication.Interfaces;
using Olimpia.Mongo.TransferMongo.Aplication.Services;
using Olimpia.Mongo.TransferMongo.Data.Context;
using Olimpia.Mongo.TransferMongo.Data.Repository;
using Olimpia.Mongo_TransferMongo.Domain.EventHandlers;
using Olimpia.Mongo_TransferMongo.Domain.Events;
using Olimpia.Mongo_TransferMongo.Domain.Interfaces;
using Olimpis.Momgo.Transfer.Data.Context;
using Olimpis.Momgo.Transfer.Data.Repository;

namespace Olimpia.Mongo.Rabbit.Infra.IoC
{
    public class DependencyContainer
    {
        public static void Register(IServiceCollection services)
        {
            //Domain Bus
            services.AddSingleton<IEventBus, RabbitMQBus>(sp =>
            {
                var scopeFactory = sp.GetRequiredService<IServiceScopeFactory>();
                return new RabbitMQBus(sp.GetService<IMediator>(), scopeFactory);
            });

            //Subscriptions
            services.AddTransient<TransferEventHandler>();
            //services.AddTransient<TransferMongoEventHandler>();

            //Domain Events
            services.AddTransient<IEventHandler<TransferCreatedEvent>, TransferEventHandler>();
            //services.AddTransient<IEventHandler<TransferMongoCreatedEvent>, TransferMongoEventHandler>();

            //Domain Banking Commands
            services.AddTransient<IRequestHandler<CreateTransferCommand, bool>, TransferCommandHandler>();

            //Banking Microservice - Application Services
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<ITransferService, TransferService>();
            //services.AddTransient<ITransferMongoService, TransferMongoService>();

            //Banking Microservice - Data
            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<ITransferRepository, TransferRepository>();
            //services.AddTransient<ITransferMongoRepository, TransferMongoRepository>();

            services.AddTransient<BankingDbContext>();
            services.AddTransient<TransferDbContext>();
            //services.AddTransient<Context>();
        }
    }
}
