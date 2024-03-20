using Cwiczenia_2_kontenery.Exceptions;
using Cwiczenia_2_kontenery.Intefaces;

namespace Cwiczenia_2_kontenery.Classes;

public class GazContainer : Container, IHazardNotifier
{
    private const char ContainerType = 'G';
    public double Pressure { get; set; }
    public string GazType { get; set; }
    
    public GazContainer(
        double maxWeight, double height, double wight, double containerWeight, double pressure, string gazType
        ) : base(maxWeight, height, wight, containerWeight)
    {
        Type = ContainerType;
        Pressure = pressure;
        GazType = gazType;
    }

    public override void Unload(double mass)
    {
        if(CargoWeight == 0)
            throw new ContainerEmptyException("Nothing to unload");
        
        if (CargoWeight - mass < CargoWeight*0.05)
        {
            NotifyHazard("You can not unload this much of gas!");
        }

        CargoWeight -= mass;
    }

    public void NotifyHazard(string message)
    {
        throw new OverfillException(message);
    }
}