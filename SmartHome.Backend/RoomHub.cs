using Microsoft.AspNetCore.SignalR;

namespace SmartHome.Backend;

public class RoomHub : Hub
{
    public override Task OnConnectedAsync()
    {
        return base.OnConnectedAsync();
    }

    public override Task OnDisconnectedAsync(Exception? exception)
    {
        return base.OnDisconnectedAsync(exception);
    }

    public Task UpdateRoomData(string message)
    {
        return Task.CompletedTask;
    }
}