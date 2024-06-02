namespace EF_ZAD.Exceptions;

public class WrongParameterException : Exception
{
    public WrongParameterException(string message) : base(message)
    {
    }

    public WrongParameterException()
    {
    }
}