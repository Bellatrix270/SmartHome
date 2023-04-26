using Libraries;
using SmartHome.ArduinoNano;

Lighting[] lighting = {new() {Name = "Большой свет"}, new() {Name = "Малый свет"}};
Uart uart = new Uart();

while (true)
{
    Thread.Sleep(1000);
    int peopleCount = uart.Read();

    if (peopleCount > 0)
    {
        foreach (var light in lighting)
        {
            light.On();
        }
    }
    else
    {
        foreach (var light in lighting)
        {
            light.Off();
        }
    }
}

int GetSwitchStatus(int relayPin)
{
    return 1;
}