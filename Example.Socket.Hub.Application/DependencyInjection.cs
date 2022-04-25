using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Example.Socket.Hub.Application.Interfaces;
using Example.Socket.Hub.Application.Services;

namespace Example.Socket.Hub.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration config)
    {
        services.AddScoped<IHubService, HubService>();
        services.AddScoped<IApplicationService, ApplicationService>();
        
        return services;
    }
}