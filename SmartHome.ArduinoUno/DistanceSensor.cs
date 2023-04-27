using Libraries;
using static Libraries.ArduinoNative;
using PinMode = Libraries.PinMode;

namespace SmartHome.ArduinoUno;

public class DistanceSensor
{
    public uint EchoPin { get; }
    public uint TrigPin { get; }
    public object Settings { get; set; }

    public DistanceSensor(uint echoPin, uint trigPin)
    {
        EchoPin = echoPin;
        TrigPin = trigPin;

        #region Init

        PinMode(TrigPin, PinMode.OUTPUT);
        PinMode(EchoPin, PinMode.INPUT);

        #endregion
    }

    public int GetDistance()
    {
        int distance = 0;
        DigitalWrite(TrigPin, PinState.LOW);
        DelayMicroseconds(2);
        DigitalWrite(TrigPin, PinState.HIGH);
        DelayMicroseconds(10);
        DigitalWrite(TrigPin, PinState.LOW);
        distance = (int)(PulseIn(EchoPin, PinState.HIGH) / 58);
        
        distance = int.Parse(Console.ReadLine()!);
        return distance;
    }
}