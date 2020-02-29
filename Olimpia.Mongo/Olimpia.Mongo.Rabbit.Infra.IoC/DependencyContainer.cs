using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Olimpia.Mongo.Bankin.Aplication.Interfaces;
using Olimpia.Mongo.Bankin.Aplication.Services;
using Olimpia.Mongo.Bankin.Data.Context;
using Olimpia.Mongo.Bankin.Data.Repository;
using Olimpia.Mongo.Bankin.Domain.Interfaces;
using Olimpia.Mongo.Domain.core.Bus;
using Olimpia.Mongo.Rabbit.Infra.Bus;

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

            ////Subscriptions
            //services.AddTransient<TransferEventHandler>();

            ////Domain Events
            //services.AddTransient<IEventHandler<TransferCreatedEvent>, TransferEventHandler>();

            ////Domain Banking Commands
            //services.AddTransient<IRequestHandler<CreateTransferCommand, bool>, TransferCommandHandler>();

            //Banking Microservice - Application Services
            services.AddTransient<IAccountService, AccountService>();
            //services.AddTransient<ITransferService, TransferService>();

            //Banking Microservice - Data
            services.AddTransient<IAccountRepository, AccountRepository>();
            //services.AddTransient<ITransferRepository, TransferRepository>();

            services.AddTransient<BankingDbContext>();
            //services.AddTransient<TransferDbContext>();
        }
    }
}
