using Libraries;

namespace SmartHome.ArduinoNano;
using static Libraries.ArduinoNative;

public class Lighting
{
    public string Name { get; set; }
    public uint FirstRelayPin { get; set; }
    public uint SecondRelayPin { get; set; }
    public uint HallSensorPin { get; set; }
    private bool IsActive { get; set; }
    
    public Lighting(uint firstRelayPin, uint secondRelayPin, uint hallSensorPin)
    {
        FirstRelayPin = firstRelayPin;
        SecondRelayPin = secondRelayPin;
        HallSensorPin = hallSensorPin;
    }

    public void Off()
    {
        IsActive = false;
    }

    public void On()
    {
        IsActive = true;
    }
    
    public int GetSwitchState()
    {
        var firstRelayData = DigitalRead(FirstRelayPin);
        var secondRelayData = DigitalRead(SecondRelayPin);
        var hallData = 1;

        if (firstRelayData == 0 && secondRelayData == 0 && hallData == 1)
        {
            return 1;
        }
        
        return 1;
    }
}