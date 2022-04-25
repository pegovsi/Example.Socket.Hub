using Example.Socket.Hub.Application.Hubs;
using Example.Socket.Hub.Application.Interfaces;

namespace Example.Socket.Hub.Presentation.Hub;

public class ClientHub : CenterHub
{
    public ClientHub(IApplicationService applicationService) 
        : base(applicationService)
    {
    }
}