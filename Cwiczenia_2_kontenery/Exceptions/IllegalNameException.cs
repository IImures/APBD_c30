namespace Cwiczenia_2_kontenery.Exceptions;

public class IllegalNameException : Exception
{
    public IllegalNameException()
    {
    }
    
    public IllegalNameException(string message) : base(message)
    {
    }
}