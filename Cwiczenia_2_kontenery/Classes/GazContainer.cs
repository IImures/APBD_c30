using Cwiczenia_2_kontenery.Exceptions;
using Cwiczenia_2_kontenery.Intefaces;

namespace Cwiczenia_2_kontenery.Classes;

public class GazContainer : Container, IHazardNotifier
{
    private const char ContainerType = 'G';
    public double Pressure { get; set; }
    public Cargo Cargo { get; }
    
    public GazContainer(
        double maxWeight, double height, double wight, double containerWeight, double pressure, Cargo cargo
        ) : base(maxWeight, height, wight, containerWeight)
    {
        Type = ContainerType;
        Pressure = pressure;
        Cargo = cargo;
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

    public override string ToString()
    {
        return $"Container ID: {Id}, Type: {Type}, " +
               $"Weight: {Weight}, Number: {Number}, " +
               $"GasType: {Cargo.Name}, Pressure: {Pressure}";
    }
}