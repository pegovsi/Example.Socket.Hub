namespace Example.Socket.Hub.Application.Interfaces;

public interface IApplicationService
{
    Task SendToFrontAsync(
        string method,
        object @event,
        IReadOnlyList<string> userIds,
        CancellationToken cancellationToken = default);

    Task PushToBus<T>(T message, CancellationToken cancellationToken = default);
}