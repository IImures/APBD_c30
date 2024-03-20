namespace Cwiczenia_2_kontenery.Classes;

public class Cargo
{
    public string Name { get; }
    public double Temperature { get;}
    
    public Cargo(string name, double temperature)
    {
        Name = name;
        Temperature = temperature;
    }
}