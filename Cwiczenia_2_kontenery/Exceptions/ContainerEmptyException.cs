namespace Cwiczenia_2_kontenery.Exceptions;

public class ContainerEmptyException : Exception
{
    public ContainerEmptyException()
    {
    }
    
    public ContainerEmptyException(string message) : base(message)
    {
    }
}