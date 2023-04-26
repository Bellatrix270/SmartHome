using SmartHome.ArduinoUno.Enums;
using Libraries;

#region States

State state = State.Calm;
byte peopleCount = 0;
byte interationsNotCalm = 0;
Uart uart = new Uart();

#endregion

const int rangeToDetect = 61;

while (true)
{
    Console.Write("Данные первого датчика:");
    int firstRange = int.Parse(Console.ReadLine()!);
    Console.Write("Данные второго датчика:");
    int secondRange = int.Parse(Console.ReadLine()!);
    
    if (interationsNotCalm == 3)
    {
        state = State.Calm;
    }

    interationsNotCalm = firstRange > rangeToDetect && secondRange > rangeToDetect ? (byte)(interationsNotCalm + 1) : (byte)0;

    while (true)
    {
        #region Entering

        if (firstRange < rangeToDetect && secondRange > rangeToDetect && state == State.Calm)
        {
            state = State.EnteringFirstStage;
            break;
        }

        if (firstRange > rangeToDetect && secondRange < rangeToDetect && state == State.EnteringFirstStage)
        {
            state = State.EnteringSecondStage;
            break;
        }

        if (firstRange > rangeToDetect && secondRange > rangeToDetect && state == State.EnteringSecondStage)
        {
            peopleCount++;
            state = State.Calm;
        }

        #endregion

        #region Leaving

        if (peopleCount == 0)
            break;
        
        if (secondRange < rangeToDetect && firstRange > rangeToDetect && state == State.Calm)
        {
            state = State.LeavingFirstStage;
            break;
        }

        if (firstRange < rangeToDetect && secondRange > rangeToDetect && state == State.LeavingFirstStage)
        {
            state = State.LeavingSecondStage;
            break;
        }

        if (firstRange > rangeToDetect && secondRange > rangeToDetect && state == State.LeavingSecondStage)
        {
            peopleCount--;
            state = State.Calm;
            break;
        }
        
        #endregion
        
        break;
    }
    
    uart.Write(peopleCount);
    
    Console.WriteLine($"Кол-во людей: {peopleCount}");
    Console.WriteLine($"Статус: {state}");
    Console.WriteLine("--------------------------------");
}