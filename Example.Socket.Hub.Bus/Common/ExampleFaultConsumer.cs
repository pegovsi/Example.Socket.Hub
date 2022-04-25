using MassTransit;
using Microsoft.Extensions.Logging;

namespace Example.Socket.Hub.Bus.Common;

public abstract class ExampleFaultConsumer<TCommand, TEvent> : IConsumer<Fault<TEvent>>
    where TEvent : class
{
    protected ILogger<TCommand> Logger { get; }
   
    protected ExampleFaultConsumer(ILogger<TCommand> logger)
    {
        Logger = logger;
    }

    public abstract Task Consume(ConsumeContext<Fault<TEvent>> context);
}