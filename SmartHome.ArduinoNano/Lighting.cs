namespace SmartHome.ArduinoNano;

public class Lighting
{
    public string Name { get; set; }
    private bool IsActive { get; set; }

    public void Off()
    {
        IsActive = false;
    }

    public void On()
    {
        IsActive = true;
    }
}