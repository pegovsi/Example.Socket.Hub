namespace Example.Socket.Hub.Application.Interfaces;

public interface IHubService
{
    Task SendMessage(
        string method,
        object @event,
        IReadOnlyList<string> userIds,
        CancellationToken cancellationToken = default);
}