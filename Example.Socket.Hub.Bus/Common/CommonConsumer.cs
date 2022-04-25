using MassTransit;
using Microsoft.Extensions.Logging;
using Example.Socket.Hub.Application.Interfaces;

namespace Example.Socket.Hub.Bus.Common;

public abstract class CommonConsumer<TEvent> : IConsumer<TEvent> 
    where TEvent :  class
{
    protected IApplicationService ApplicationService { get; }
    protected ILoggerFactory LoggerFactory { get; }

    protected CommonConsumer(ILoggerFactory loggerFactory, IApplicationService applicationService)
    {
        LoggerFactory = loggerFactory;
        ApplicationService = applicationService;
    }

    public abstract Task Consume(ConsumeContext<TEvent> context);
}