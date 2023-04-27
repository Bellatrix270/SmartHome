using Libraries;
using SmartHome.ArduinoNano;

Lighting[] lighting = 
    {
        new(1,2,3) {Name = "Большой свет"},
        new(4,5,6) {Name = "Малый свет"}
    };
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
    
    uart.Write(115);
}