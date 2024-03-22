using Cwiczenia_2_kontenery.Classes.Cargo;
using Cwiczenia_2_kontenery.Classes.Containers;
using Cwiczenia_2_kontenery.Classes.Ship;

namespace Cwiczenia_2_kontenery.Data;

public class DataManager
{
    private  List<Cargo?> _coolCargo = new();
    private  List<Cargo> _liquidCargo = new();
    private  List<Cargo> _gazCargo = new ();

    private  List<Container> _containers = new ();
    private  List<Ship> _ships = new();

    public DataManager()
    {
        _coolCargo.Add(new Cargo("Banany", 15));
        _coolCargo.Add(new Cargo("Mleko", 5));
        _coolCargo.Add(new Cargo("Mięso", 0));
        _coolCargo.Add(new Cargo("Miod", 20));

        _liquidCargo.Add(new Cargo("Woda", false));
        _liquidCargo.Add(new Cargo("Paliwo", true));
        _liquidCargo.Add(new Cargo("Kwas", true));
        _liquidCargo.Add(new Cargo("Tea", false));

        _gazCargo.Add(new Cargo("Azot"));
        _gazCargo.Add(new Cargo("Tlen"));
        _gazCargo.Add(new Cargo("Wodór"));
        _gazCargo.Add(new Cargo("Hel"));
        
        _ships.Add(new Ship("Terra", 1000, 10));
        _containers.Add(new CoolContainer(1000,100,50,30,10, _coolCargo[0]));
    }

    public Cargo? FindCargo(string cargoName)
    {
        Cargo? result;
        result = _coolCargo.Find(c => c.Name == cargoName);
        if (result != null) return result;
        result = _gazCargo.Find(c => c.Name == cargoName);
        if (result != null) return result;
        result = _liquidCargo.Find(c => c.Name == cargoName);
        return result;
    }
    
    public Ship? GetShipById(int id)
    {
        foreach (var ship in _ships)
        {
            if (ship.Id == id) return ship;
        }

        return null;
    }
    
    public Container? GetContainerById(int id)
    {
        foreach (Container container in _containers)
        {
            if (container.Id == id) return container;
        }

        return null;
    }

    public void AddShip(Ship ship)
    {
        _ships.Add(ship);
    }
    
    public void AddContainer(Container container)
    {
        _containers.Add(container);
    }

    public void AddLiquidCargo(Cargo liquidCargo)
    {
        _liquidCargo.Add(liquidCargo);
    }

    public void AddCoolCargo(Cargo? cargo)
    {
        _coolCargo.Add(cargo);
    }

    public void AddGazCargo(Cargo cargo)
    {
        _gazCargo.Add(cargo);
    }

    public bool IsCargoAvailable()
    {
        return _coolCargo.Count > 0 || _liquidCargo.Count > 0 || _gazCargo.Count > 0;
    }
    
    public void PrintAllCargo()
    {
        foreach (Cargo? cargo in _coolCargo)
        {
            Console.WriteLine(cargo);
        }
        foreach (Cargo cargo in _liquidCargo)
        {
            Console.WriteLine(cargo);
        }
        foreach (Cargo cargo in _gazCargo)
        {
            Console.WriteLine(cargo);
        }
    }

    public void PrintCoolContainers()
    {
        foreach (Cargo? cargo in _coolCargo)
        {
            Console.WriteLine(cargo);
        }
    }
    
    public void PrintLiquidContainers()
    {
        foreach (Cargo cargo in _liquidCargo)
        {
            Console.WriteLine(cargo);
        }
    }
    
    public void PrintGazContainers()
    {
        foreach (Cargo cargo in _gazCargo)
        {
            Console.WriteLine(cargo);
        }
    }

    public void PrintAllCoolCargo()
    {
        foreach (Cargo? cargo in _coolCargo)
        {
            Console.WriteLine(cargo);
        }
    }
    
    public void PrintAllContainers()
    {
        foreach (Container container in _containers)
        {
            Console.WriteLine(container);
        }
    }
    
    public void PrintAllShips()
    {
        foreach (Ship ship in _ships)
        {
            Console.WriteLine(ship);
        }
    }
    
    
    public int ShipCount
    {
        get => _ships.Count;
    }
    
    public int ContainerCount
    {
        get => _containers.Count;
    }


    public void DeleteShipById(int id)
    {
        Ship toRemove = null!;
        foreach (var ship in _ships)
        {
            if (ship.Id == id) toRemove = ship;
        }

        if (toRemove != null)
            _ships.Remove(toRemove);
    }

    public void DeleteContainer(Container container)
    {
        _containers.Remove(container);
    }

    public Container? FindContainerById(int id)
    {
        foreach (Container container in _containers)
        {
            if (container.Id == id) return container;
        }

        return null;
    }
}