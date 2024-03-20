using Cwiczenia_2_kontenery.Exceptions;
using Cwiczenia_2_kontenery.Intefaces;

namespace Cwiczenia_2_kontenery.Classes;

public class LiquidContainer : Container, IHazardNotifier
{
    private const char ContainerType = 'L';
    
    public string LiquidType { get; set; }
    public bool IsHazardous { get; set; }
    
    public LiquidContainer(
        double maxWeight, double height, double wight, double containerWeight, string liquidType, bool isHazardous
        ) : base(maxWeight, height, wight, containerWeight)
    {
        Type = ContainerType;
        LiquidType = liquidType;
        IsHazardous = isHazardous;
    }
    
    public override void Load(double mass)
    {
        if(IsHazardous) LoadHazardous(mass);
        else LoadSafe(mass);
    }
    
    private void LoadHazardous(double mass)
    {
        if (mass == 0)
            throw new OverfillException("Nothing to load");
        if (CargoWeight + mass > MaxWeight * 0.5)
            NotifyHazard("For hazardous liquid you can load only 50% of container weight!");
        CargoWeight += mass;
    }
    
    private void LoadSafe(double mass)
    {
        if (mass == 0)
            throw new OverfillException("Nothing to load");
        if (CargoWeight + mass > MaxWeight * 0.9)
            throw new OverfillException("For regular liquid you can load only 90% of container weight!");
        CargoWeight += mass;        
    }

    public void NotifyHazard(string message)
    {
        throw new OverfillException(message);
    }

    public override string ToString()
    {
        return $"Container ID: {Id}, Type: {Type}, " +
               $"Weight: {Weight}, Number: {Number}, " +
               $"LiquidType: {LiquidType}, IsHazardous: {IsHazardous}";
    }
}