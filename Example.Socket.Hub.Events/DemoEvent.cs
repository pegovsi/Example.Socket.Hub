namespace Example.Socket.Hub.Events;

public record DemoEvent
{
    public Guid[] UserIds { get; init; }
}