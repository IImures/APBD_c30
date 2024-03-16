namespace Cwiczenia_2_kontenery.Exceptions;

public class OverfillException : Exception
{
    public OverfillException()
    {
    }
    
    public OverfillException(string message) : base(message)
    {
    }
}