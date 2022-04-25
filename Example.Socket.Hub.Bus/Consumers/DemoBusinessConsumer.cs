using MassTransit;
using Microsoft.Extensions.Logging;
using Example.Socket.Hub.Application.Common;
using Example.Socket.Hub.Application.Interfaces;
using Example.Socket.Hub.Application.Models;
using Example.Socket.Hub.Bus.Common;
using Example.Socket.Hub.Events;

namespace Example.Socket.Hub.Bus.Consumers;

internal sealed class DemoBusinessConsumer : CommonConsumer<DemoEvent>
{
    private readonly ILogger<DemoBusinessConsumer> _logger;
    public DemoBusinessConsumer(ILoggerFactory loggerFactory, IApplicationService applicationService)
        : base(loggerFactory, applicationService)
    {
        _logger = loggerFactory.CreateLogger<DemoBusinessConsumer>();
    }

    public override Task Consume(ConsumeContext<DemoEvent> context)
    {
        var userIds = new []
        {
            //DEMO: Convert from context.Message.UserIds
            Guid.NewGuid().ToString()
        };

        //DEMO: Creating model for front client
        var model = new DemoModel
        {
            Data = "Demo data"
        };
        
        _logger.LogInformation("Send to front: {@Model}", model);
        return ApplicationService.SendToFrontAsync(
            FrontMethods.UpdateMethod,
            model,
            userIds,
            context.CancellationToken);
    }
}