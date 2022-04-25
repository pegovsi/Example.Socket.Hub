using MassTransit;
using Microsoft.Extensions.Logging;
using Example.Socket.Hub.Application.Interfaces;

namespace Example.Socket.Hub.Bus.Services;

internal class BusService : IBusService
{
    private readonly IBus _bus;
    private readonly ILogger<BusService> _logger;

    public BusService(IBus bus, ILogger<BusService> logger)
    {
        _bus = bus;
        _logger = logger;
    }

    public Task Push<T>(T message, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Send to bus Message: {Message}", message);
        return _bus.Publish(message, cancellationToken);
    }
}