namespace Example.Socket.Hub.Application.Interfaces;

public interface IBusService
{
    Task Push<T>(T message, CancellationToken cancellationToken = default);
}