using MassTransit;
using MassTransit.RabbitMqTransport;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Example.Socket.Hub.Bus.Consumers;
using Example.Socket.Hub.Events;

namespace Example.Socket.Hub.Bus.Extensions;

public static class BusExtension
{
    public static IServiceCollection AddBusService(this IServiceCollection services, IConfiguration config)
    {
        services.AddMassTransit(x =>
        {
            x.AddConsumer<DemoBusinessConsumer>();
            // x.AddConsumer<ExampleFaultConsumer>();
            
            x.AddBus(provider =>
            {
                var bus = MassTransit.Bus.Factory.CreateUsingRabbitMq(cfg =>
                {
                    cfg.Host(new Uri($"rabbitmq://{config["RMQClient:Host"]}/"), hostConfig =>
                    {
                        hostConfig.Username(config["RMQClient:UserName"]);
                        hostConfig.Password(config["RMQClient:Password"]);
                    });
            
                    AddReceiveEndpoint<DemoBusinessConsumer>(nameof(DemoEvent), cfg, provider);
                    // AddReceiveEndpoint<ExampleFaultConsumer>(cfg, provider);
                });
                return bus;
            });
        });

        services.AddMassTransitHostedService();
        services.AddSingleton<IBus>(provider => provider.GetRequiredService<IBusControl>());

        return services;
    }

    private static void AddReceiveEndpoint<T>(string name,
        IRabbitMqBusFactoryConfigurator configurator, IRegistration provider)
        where T : class, IConsumer
    {
        configurator.ReceiveEndpoint(name, configure => { configure.ConfigureConsumer<T>(provider); });
    }

    private static void AddReceiveEndpoint<T>(IRabbitMqBusFactoryConfigurator configurator, IRegistration provider)
        where T : class, IConsumer
    {
        configurator.ReceiveEndpoint(configure => { configure.ConfigureConsumer<T>(provider); });
    }
}