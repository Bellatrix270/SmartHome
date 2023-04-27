namespace Libraries;

public static class ArduinoNative
{
    public static void DigitalWrite(uint pin, PinState value)
    {
        
    }

    public static PinState DigitalRead(uint pin)
    {
        return default(PinState);
    }

    public static void PinMode(uint pin, PinMode mode)
    {
        
    }

    public static void DelayMicroseconds(uint microseconds)
    {
        
    }

    public static long PulseIn(uint pin, PinState state)
    {
        return default(long);
    }
}

public enum PinState
{
    LOW,
    HIGH
}

public enum PinMode
{
    OUTPUT,
    INPUT
}