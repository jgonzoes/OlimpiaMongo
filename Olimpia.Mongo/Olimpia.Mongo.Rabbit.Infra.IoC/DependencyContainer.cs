using MediatR;
using Microsoft.Extensions.DependencyInjection;
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


        }
    }
}
