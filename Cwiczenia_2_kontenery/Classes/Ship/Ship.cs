using Cwiczenia_2_kontenery.Classes.Containers;
using Cwiczenia_2_kontenery.Exceptions;

namespace Cwiczenia_2_kontenery.Classes.Ship;

public class Ship
{
    private static int _idCounter = 0;
    public int Id { get; }
    public List<Container> Containers { get; set; }
    public string Name { get; set; }
    public double MaxWeight { get; }
    public int MaxContainers { get; }
    
    public Ship(string name, double maxWeight, int maxContainers)
    {
        Id = _idCounter++;
        Name = name;
        MaxWeight = maxWeight;
        MaxContainers = maxContainers;
        Containers = new List<Container>();
    }
    
    public void AddContainer(Container container)
    {
        if (Containers.Count >= MaxContainers)
            throw new OverfillException("To much containers");
        if (container.Weight + Containers.Sum(c => c.Weight) > MaxWeight)
            throw new OverfillException("To much weight");
        Containers.Add(container);
    }
    public void Unload(int containerId)
    {
        var container = Containers.FirstOrDefault(c => c.Id == containerId);
        if (container == null)
            throw new ContainerNotFoundException("Container not found");
        Containers.Remove(container);
    }
    
    public int ContainerCount {
        get=> Containers.Count;
    }

    public override string ToString()
    {
        return $"Ship ID: {Id}, Name: {Name}, MaxWeight: {MaxWeight}, MaxContainers: {MaxContainers}, ContainerCount: {ContainerCount}";
    }
}

