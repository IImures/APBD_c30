using Cwiczenia_2_kontenery.Exceptions;

namespace Cwiczenia_2_kontenery.Classes;

public class CoolContainer : Container
{
    private const char ContainerType = 'C';
    
    private double ContainerTemperature { get; set; }
    public CoolContainer(
        double maxWeight, double height, double wight, double containerWeight, 
        double containerTemperature, Cargo cargo
        ) : base(maxWeight, height, wight, containerWeight, cargo)
    {
        Type = ContainerType;
        ContainerTemperature = containerTemperature;

        if (cargo.Temperature < containerTemperature)
            throw new WrongContainerTemperature("Container temperature is higher than cargo temperature");
    }

    public string CargoName {
        get=> Cargo.Name;
    }
    
    public double CargoTemperature {
        get=> Cargo.Temperature;
    }
    
    public override string ToString()
    {
        return $"Container ID: {Id}, Type: {Type}, " +
               $"Weight: {Weight}, Number: {Number}, " +
               $"Cargo: {CargoName}, CargoTemperature: {CargoTemperature}, " +
               $"ContainerTemperature: {ContainerTemperature}";
    }
}