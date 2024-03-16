using Cwiczenia_2_kontenery.Exceptions;

namespace Cwiczenia_2_kontenery.Classes;

public abstract class Container
{
    private static int _numberOfContainers = 0;
    public int Id { get; set; }
    public int MaxMass { get; set; }
    public int Height { get; set; }
    public int Wight { get; set; }
    public int Weight { get; set; }
    protected char Type{get; set;}

    protected Container()
    {
        _numberOfContainers++;
        Id = _numberOfContainers;
    }
    
    public void Load(int mass)
    {
        if (Weight + mass > MaxMass)
        {
            throw new OverfillException("To much load");
        }
        Weight += mass;
    }
    
    protected Container(int maxMass, int height, int wight, int weight)
    {
        _numberOfContainers++;
        Id = _numberOfContainers;
        MaxMass = maxMass;
        Height = height;
        Wight = wight;
        Weight = weight;
    }
    public string Number
    {
        get => $"KON-{Type}-{Id}";
    }

}