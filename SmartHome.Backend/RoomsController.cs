using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace SmartHome.Backend;

[ApiController]
[Route("[controller]")]
public class RoomsController : Controller
{
    private readonly IHubContext<RoomHub> _hubContext;
    public static List<Room> Rooms { get; set; } = new List<Room>();

    public RoomsController(IHubContext<RoomHub> hubContext)
    {
        _hubContext = hubContext;
    }
    
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(Rooms);
    }
    
    [HttpPut]
    public async Task<IActionResult> Put([FromBody] Room room)
    {
        Rooms.Add(room);
        await _hubContext.Clients.All.SendAsync("UpdateRoomsData", Rooms);
        return Ok();
    }
}

public class Room
{
    public string Name { get; set; }
    public byte PeopleCount { get; set; }
}