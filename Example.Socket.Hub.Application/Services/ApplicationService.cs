using Example.Socket.Hub.Application.Interfaces;

namespace Example.Socket.Hub.Application.Services;

internal sealed class ApplicationService : IApplicationService
{
    private readonly IHubService _hubService;
    private readonly IBusService _busService;

    public ApplicationService(IHubService hubService, IBusService busService)
    {
        _hubService = hubService;
        _busService = busService;
    }

    public Task SendToFrontAsync(
        string method,
        object @event,
        IReadOnlyList<string> userIds,
        CancellationToken cancellationToken = default)
    {
        return _hubService.SendMessage(method,
            @event,
            userIds,
            cancellationToken);
    }
    
    public Task PushToBus<T>(T message, CancellationToken cancellationToken = default)
    {
        return _busService.Push(message, cancellationToken);
    }
}