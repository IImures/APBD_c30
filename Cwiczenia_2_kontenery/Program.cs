using Cwiczenia_2_kontenery.Classes;
using Cwiczenia_2_kontenery.Exceptions;

public class Program
{
    public static void Main(string[] args)
    {
        Container container = new CoolContainer(10, 20,30, 40);
        container.MaxMass = 100;
        container.Height = 10;
        container.Wight = 10;
        container.Weight = 10;
        Console.WriteLine(container.Number);
        Console.WriteLine(container.MaxMass);
        Console.WriteLine(container.Height);
        Console.WriteLine(container.Wight);
        Console.WriteLine(container.Weight);
    }
}