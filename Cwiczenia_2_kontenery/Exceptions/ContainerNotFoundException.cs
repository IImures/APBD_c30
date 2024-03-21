namespace Cwiczenia_2_kontenery.Exceptions;

public class ContainerNotFoundException : Exception
{

    public ContainerNotFoundException()
    {
    }

    public ContainerNotFoundException(string containerNotFound) : base(containerNotFound)
    {
    }
}