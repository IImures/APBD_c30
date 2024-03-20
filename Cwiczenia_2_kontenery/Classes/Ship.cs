namespace Cwiczenia_2_kontenery.Classes;

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
    
    public int ContainerCount {
        get=> Containers.Count;
    }

    public override string ToString()
    {
        return $"Ship ID: {Id}, Name: {Name}, MaxWeight: {MaxWeight}, MaxContainers: {MaxContainers}, ContainerCount: {ContainerCount}";
    }
}