using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Example.Socket.Hub.Application;

namespace Example.Socket.Hub.Presentation;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services, IConfiguration config)
    {
        services.AddApplication(config);
        return services;
    }
}