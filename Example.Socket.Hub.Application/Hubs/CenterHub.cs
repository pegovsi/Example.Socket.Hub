using Microsoft.AspNetCore.SignalR;
using Example.Socket.Hub.Application.Interfaces;

namespace Example.Socket.Hub.Application.Hubs;

public class CenterHub : Microsoft.AspNetCore.SignalR.Hub
{
    protected readonly IApplicationService ApplicationService;
    
    public CenterHub(IApplicationService applicationService)
    {
        ApplicationService = applicationService;
    }

    public override Task OnConnectedAsync()
    {
        return base.OnConnectedAsync();
    }
    
    public override Task OnDisconnectedAsync(Exception exception)
    {
        return base.OnDisconnectedAsync(exception);
    }

    public Task SendMessage(string message)
    {
        var rnd = new Random();
        return Clients.All.SendAsync("ReceiveMessage", message + " response " + rnd.Next(1, 200));
    }
}