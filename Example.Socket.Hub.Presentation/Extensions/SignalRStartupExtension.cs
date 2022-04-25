using System.Net;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

namespace Example.Socket.Hub.Presentation.Extensions;

public static class SignalRStartupExtension
{
       public static IServiceCollection AddSignalRService(this IServiceCollection services, IConfiguration config)
    {
        services.AddSignalR(opt => { opt.EnableDetailedErrors = true; })
            .AddStackExchangeRedis(c =>
            {
                c.ConnectionFactory = async w =>
                {
                    var options = new ConfigurationOptions
                    {
                        AbortOnConnectFail = false,
                        DefaultDatabase = int.Parse(config["ConnectionStrings:RedisConnection:DefaultDatabase"])
                    };
            
                    //Parse(config["ConnectionStrings:RedisConnection:Host"]
                    // int.Parse(config["ConnectionStrings:RedisConnection:Port"]
                    options.EndPoints.Add(IPAddress.Loopback, 0);
                    options.SetDefaultPorts();
                    options.Password = config["ConnectionStrings:RedisConnection:Password"];
                    var connection = await ConnectionMultiplexer.ConnectAsync(options, w);
                    connection.ConnectionFailed += (o, e) =>
                    {
                        Console.WriteLine("SignalR connection to Redis failed.");
                    };
            
                    Console.WriteLine(connection.IsConnected
                        ? "SignalR connected to Redis success."
                        : "SignalR did not connect to Redis.");
            
                    return connection;
                };
            });

        services.AddStackExchangeRedisCache(opt =>
        {
            opt.Configuration =
                $"{config["ConnectionStrings:RedisConnection:host"]}:{config["ConnectionStrings:RedisConnection:port"]}," +
                $"{config["ConnectionStrings:RedisConnection:connectionString"]}," +
                $"DefaultDatabase={config["ConnectionStrings:RedisConnection:CacheDatabase"]}";
        });

        return services;
    }

}