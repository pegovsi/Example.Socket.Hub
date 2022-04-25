using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Example.Socket.Hub.Application.Interfaces;
using Example.Socket.Hub.Bus.Extensions;
using Example.Socket.Hub.Bus.Services;

namespace Example.Socket.Hub.Bus;

public static class DependencyInjection
{
    public static IServiceCollection AddBus(this IServiceCollection services, IConfiguration config)
    {
        services.AddScoped<IBusService, BusService>();

        services
            .AddBusService(config);
        return services;
    }
}