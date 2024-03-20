using Cwiczenia_2_kontenery.Classes;

public class Program
{
    public static void Main(string[] args)
    {
        List<Cargo> cargoTypes = new List<Cargo>();
        cargoTypes.Add(new Cargo("Banany", 15));
        cargoTypes.Add(new Cargo("Mleko", 5));
        cargoTypes.Add(new Cargo("Mięso", 0));
        
        Container coolContainer = new CoolContainer(1000, 2, 2, 100, 5, cargoTypes[0]);
        coolContainer.Load(100);
        Console.WriteLine(coolContainer);
        coolContainer.Unload(50);
        Console.WriteLine(coolContainer);
        
        
        Container liquidContainer = new LiquidContainer(1000, 2, 2, 100, "Woda", false);
        liquidContainer.Load(900);
        Console.WriteLine(liquidContainer);
        
        Container liquidContainer2 = new LiquidContainer(1000, 2, 2, 100, "Paliwo", true);
        liquidContainer2.Load(500);
        Console.WriteLine(liquidContainer2);
    }
}