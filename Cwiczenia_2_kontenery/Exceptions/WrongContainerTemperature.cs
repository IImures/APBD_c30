namespace Cwiczenia_2_kontenery.Exceptions;

public class WrongContainerTemperature : Exception
{
    public WrongContainerTemperature()
    {
    }
    
    public WrongContainerTemperature(string message) : base(message)
    {
    }
}