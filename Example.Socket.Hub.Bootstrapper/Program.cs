using Example.Socket.Hub.Bootstrapper.Extensions;
using Example.Socket.Hub.Bus;
using Example.Socket.Hub.Presentation;
using Example.Socket.Hub.Presentation.Extensions;
using Example.Socket.Hub.Presentation.Hub;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSignalR();
builder.Services.AddSwaggerGen()
    .AddCorsConfig(builder.Configuration)
    .AddPresentation(builder.Configuration)
    .AddBus(builder.Configuration)
    .AddSignalRService(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();
app.MapHub<ClientHub>("/hub/manager");

app.Run();