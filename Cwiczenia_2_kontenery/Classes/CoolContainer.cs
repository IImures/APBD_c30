namespace Cwiczenia_2_kontenery.Classes;

public class CoolContainer : Container
{
    private const char ContainerType = 'C';
    
    public Cargo Cargo { get;}

    public CoolContainer(
        double maxWeight, double height, double wight, double containerWeight, Cargo cargo
        ) : base(maxWeight, height, wight, containerWeight)
    {
        Type = ContainerType;
        Cargo = cargo;
    }

    public string CargoName {
        get=> Cargo.Name;
    }
    
    public double CargoTemperature {
        get=> Cargo.Temperature;
    }
    
    public override string ToString()
    {
        return $"Container ID: {Id}, Type: {Type}, Weight: {Weight}, Number: {Number}, Cargo: {CargoName}, Temperature: {CargoTemperature}";
    }
}