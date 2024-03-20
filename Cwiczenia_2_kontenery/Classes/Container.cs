using Cwiczenia_2_kontenery.Exceptions;

namespace Cwiczenia_2_kontenery.Classes;

public abstract class Container
{
    private static int _numberOfContainers = 0;
    public int Id { get; set; }
    public double CargoWeight { get; set; }
    public double Height { get; set; }
    public double Wight { get; set; }
    public double ContainerWeight { get; set; }
    public double MaxWeight { get; set; }
    protected char Type{get; set;}

    protected Container()
    {
        _numberOfContainers++;
        Id = _numberOfContainers;
    }
    
    protected Container(double maxWeight, double height, double wight, double containerWeight)
    {
        _numberOfContainers++;
        Id = _numberOfContainers;
        MaxWeight = maxWeight;
        CargoWeight = 0;
        Height = height;
        Wight = wight;
        ContainerWeight = containerWeight;
    }
    
    public void Load(double mass)
    {
        if (Weight + mass > MaxWeight)
        {
            throw new OverfillException("To much load");
        }
        CargoWeight += mass;
    }
    
    public void Unload(double mass)
    {
        if (CargoWeight - mass < 0)
        {
            throw new OverfillException("To much unload");
        }
        CargoWeight -= mass;
    }
    
    public string Number
    {
        get => $"KON-{Type}-{Id}";
    }
    
    public double Weight
    {
        get => ContainerWeight + CargoWeight;
    }

}