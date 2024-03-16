namespace Cwiczenia_2_kontenery.Classes;

public class CoolContainer : Container
{
    private const char ContainerType = 'C';

    public CoolContainer(int maxMass, int height, int wight, int weight) : base(maxMass, height, wight, weight)
    {
        Type = ContainerType;
    }
}