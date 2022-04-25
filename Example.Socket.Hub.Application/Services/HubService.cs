using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using Example.Socket.Hub.Application.Hubs;
using Example.Socket.Hub.Application.Interfaces;

namespace Example.Socket.Hub.Application.Services;

internal sealed class HubService : IHubService
{
    private readonly IHubContext<CenterHub> _context;
    private readonly ILogger<HubService> _logger;

    public HubService(IHubContext<CenterHub> context, ILogger<HubService> logger)
    {
        _context = context;
        _logger = logger;
    }

    public Task SendMessage(
        string method,
        object @event,
        IReadOnlyList<string> userIds,
        CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Send to front Message: {Model}; front method: {Method}", @event, method);
        return _context.Clients.Users(userIds)
            .SendAsync("", @event, cancellationToken);
    }
}