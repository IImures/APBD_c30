using Cwiczenia_2_kontenery.Classes;
using Cwiczenia_2_kontenery.Exceptions;

namespace Cwiczenia_2_kontenery;

public class Program
{
    private static List<Cargo> _coolCargo = new();
    private static List<Cargo> _liquidCargo = new();
    private static List<Cargo> _gazCargo = new ();

    private static List<Container> _containers = new ();
    private static List<Ship> _ships = new();

    public static void Main(string[] args)
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



        while (true)
        {
            Console.WriteLine("--------------------");
            if(_gazCargo.Count == 0 && _liquidCargo.Count == 0 && _coolCargo.Count == 0)
                Console.WriteLine("No Cargo available.");
            else
            {
                Console.WriteLine("Cargo available:");
                foreach (Cargo cargo in _coolCargo)
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
            Console.WriteLine("--------------------");
            if (_containers.Count == 0)
            {
                Console.WriteLine("No Containers available.");
            }
            else
            {
                Console.WriteLine(_containers.Count > 1 ? "Containers available:" : "Container available:");
                foreach (var container in _containers)
                {
                    Console.WriteLine(container);
                }
            }
            Console.WriteLine("--------------------");
            if (_ships.Count == 0)
            {
                Console.WriteLine("No Ships available.");
            }
            else
            {
                Console.WriteLine(_ships.Count >1 ? "Ships available:" : "Ship available: ");
                foreach (Ship ship in _ships)
                {
                    Console.WriteLine(ship);
                }
            }
            Console.WriteLine("--------------------");
            Console.WriteLine("Please select an option:");
            Console.WriteLine("1. Add Ship");
            if (_ships.Count > 0)
            {
                Console.WriteLine("2. Configure Ship");
                Console.WriteLine("3. Add Container");
                if (_containers.Count > 0)
                    Console.WriteLine("4. Load Container");
                Console.WriteLine("5. Add Cargo");
            }

            Console.WriteLine("6. Exit");

            string? userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1": //"1. Add Ship"
                    CreateNewShip();
                    break;
                case "2": //"2. Configure Ship"
                    Console.WriteLine("You selected Option 2");
                    if (_ships.Count == 0) break;
                    break;
                case "3": //"3. Add Container"
                    Console.WriteLine("You selected Option 2");
                    if (_ships.Count == 0) break;
                    CreateNewContainer();
                    break;
                case "4": //"4. Load Container"
                    Console.WriteLine("You selected Option 2");
                    if (_ships.Count == 0) break;
                    break;
                case "5": //"5. Add Cargo"
                    Console.WriteLine("You selected Option 2");
                    if (_ships.Count == 0) break;
                    CreateNewCargo();
                    break;
                case "6": //"6. Exit"
                    Console.WriteLine("Exiting...");
                    return;
                default:
                    Console.WriteLine("Invalid option, please try again. Press any key to continue...");
                    Console.ReadKey();
                    break;
            }
            Console.Clear();
        }
    }

    private static void CreateNewCargo()
    {
        Console.Clear();
        Console.WriteLine("Enter the type of the cargo:");
        Console.WriteLine("1. Cool Cargo");
        Console.WriteLine("2. Gaz Cargo");
        Console.WriteLine("3. Liquid Cargo");
        Console.WriteLine("4. Exit");
        string? userInput = Console.ReadLine();
        switch (userInput)
        {
            case "1":
                CreateNewCoolCargo();
                break;
            case "2":
                CreateNewGazCargo();
                break;
            case "3":
                CreateNewLiquidCargo();
                break;
            case "4":
                return;
            default:
                Console.WriteLine("Invalid option, please try again. Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
                CreateNewCargo();
                break;
        }
    }
    
    private static void CreateNewCoolCargo()
    {
        Console.Clear();
        CreateNewCoolCargo(null, null);
    }
    
    private static void CreateNewCoolCargo(string? name, double? temperature)
    {
        if (name == null)
        {
            try
            {
                Console.Write("Enter the name of the cargo: ");
                name = Console.ReadLine();
                if(string.IsNullOrEmpty(name))
                    throw new FormatException();
            }
            catch (FormatException )
            {
                Console.WriteLine("Invalid input. Please enter a valid name for the cargo.");
                CreateNewCoolCargo(null, null);
                return;
            }
        }
        if (temperature == null)
        {
            try
            {
                Console.Write("Enter the temperature of the cargo: ");
                temperature = double.Parse(Console.ReadLine()!);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter a valid number for the temperature.");
                CreateNewCoolCargo(name, null);
                return;
            }
        }
        Cargo newCargo = new Cargo(name, temperature.Value);
        _coolCargo.Add(newCargo);
        CreationNotify("Cool Cargo", newCargo.Name);
    }
    
    private static void CreateNewGazCargo()
    {
        Console.Clear();
        CreateNewGazCargo(null);
    }
    
    private static void CreateNewGazCargo(string? name)
    {
        if (name == null)
        {
            try
            {
                Console.Write("Enter the name of the cargo: ");
                name = Console.ReadLine();
                if(string.IsNullOrEmpty(name))
                    throw new FormatException();
            }
            catch (FormatException )
            {
                Console.WriteLine("Invalid input. Please enter a valid name for the cargo.");
                CreateNewGazCargo(null);
                return;
            }
        }
        Cargo newCargo = new Cargo(name);
        _gazCargo.Add(newCargo);
        CreationNotify("Gaz Cargo", newCargo.Name);
    }
    
    private static void CreateNewLiquidCargo()
    {
        Console.Clear();
        CreateNewLiquidCargo(null, null);
    }
    
    private static void CreateNewLiquidCargo(string? name, bool? isHazardous)
    {
        if (name == null)
        {
            try
            {
                Console.Write("Enter the name of the cargo: ");
                name = Console.ReadLine();
                if(string.IsNullOrEmpty(name))
                    throw new FormatException();
            }
            catch (FormatException )
            {
                Console.WriteLine("Invalid input. Please enter a valid name for the cargo.");
                CreateNewLiquidCargo(null, null);
                return;
            }
        }
        if (isHazardous == null)
        {
            try
            {
                Console.Write("Is the cargo hazardous? (Y/N): ");
                string input = Console.ReadLine().ToUpper();
                switch (input)
                {
                    case "Y":
                        isHazardous = true;
                        break;
                    case "N":
                        isHazardous = false;
                        break;
                    default:
                        throw new FormatException();
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter Y for Yes or N for No.");
                CreateNewLiquidCargo(name, null);
                return;
            }
        }
        Cargo newCargo = new Cargo(name, isHazardous.Value);
        _liquidCargo.Add(newCargo);
        CreationNotify("Liquid Cargo", newCargo.Name);
    }
    
    private static void CreateNewContainer()
    {
        Console.Clear();
        CreateNewContainer(null, null, null, null, null, null); 
    }

    private static void CreateNewContainer(char? type, double? maxWeight, double? height, double? width,
        double? containerWeight, string? cargoName, double? temperature = null, double? pressure = null)
    {
        if (type == null)
        {
            try
            {
                Console.Write("Enter the type of the container (C for Cool, L for Liquid, G for Gaz): ");
                type = char.Parse(Console.ReadLine()!);
                if (type != 'C' && type != 'L' && type != 'G')
                    throw new FormatException();
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter C for Cool, L for Liquid, or G for Gaz.");
                CreateNewContainer(null, null, null, null, null, null);
                return;
            }
        }

        if (maxWeight == null)
        {
            try
            {
                Console.Write("Enter the maximum cargo weight for the container: ");
                maxWeight = double.Parse(Console.ReadLine()!);
            }
            catch (FormatException)
            {
                Console.WriteLine(
                    "Invalid input. Please enter a valid number for the weight and number of containers.");
                CreateNewContainer(type, null, null, null, null, null);
                return;
            }
        }
        if (height == null)
        {
            try
            {
                Console.Write("Enter the height of the container: ");
                height = double.Parse(Console.ReadLine()!);
            }
            catch (FormatException)
            {
                Console.WriteLine(
                    "Invalid input. Please enter a valid number for the weight and number of containers.");
                CreateNewContainer(type, maxWeight, null, null, null, null);
                return;
            }
        }
        if (width == null)
        {
            try
            {
                Console.Write("Enter the width of the container: ");
                width = double.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine(
                    "Invalid input. Please enter a valid number for the weight and number of containers.");
                CreateNewContainer(type, maxWeight, height, null, null, null);
                return;
            }
        }
        if (containerWeight == null)
        {
            try
            {
                Console.Write("Enter the weight of the container: ");
                containerWeight = double.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine(
                    "Invalid input. Please enter a valid number for the weight and number of containers.");
                CreateNewContainer(type, maxWeight, height, width, null, null);
                return;
            }
        }

        Cargo cargo = null;
        if (cargoName == null)
        {
            try
            {
                if (type == 'C')
                {
                    foreach(Cargo cargo1 in _coolCargo)
                    {
                        Console.WriteLine(cargo1);
                    }
                }
                else if (type == 'L')
                {
                    foreach(Cargo cargo1 in _liquidCargo)
                    {
                        Console.WriteLine(cargo1);
                    }
                }
                else if (type == 'G')
                {
                    foreach(Cargo cargo1 in _gazCargo)
                    {
                        Console.WriteLine(cargo1);
                    }
                }
                Console.WriteLine("--------------------");

                Console.Write("Enter the name of the cargo: ");
                cargoName = Console.ReadLine();
                if (string.IsNullOrEmpty(cargoName))
                    throw new FormatException();
            }catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter a valid name for the cargo.");
                CreateNewContainer(type, maxWeight, height, width, containerWeight, null);
                return;
            }
            cargo = _coolCargo.Find(c => c.Name == cargoName);
            if (cargo == null)
            {
                cargo = _liquidCargo.Find(c => c.Name == cargoName);
                if (cargo == null)
                {
                    cargo = _gazCargo.Find(c => c.Name == cargoName);
                    if (cargo == null)
                    {
                        Console.WriteLine("Cargo not found. Please enter a valid cargo name. Try again. Press any key to continue...");
                        Console.ReadKey();
                        return;
                    }
                }
            }
            
        }
        
        
        Container newContainer = null;
        switch (type)
        {
            case 'C':
                if(temperature==null)
                {
                    try
                    {
                        Console.Write("Enter the temperature of the container: ");
                        temperature = double.Parse(Console.ReadLine());
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Invalid input. Please enter a valid number for the temperature.");
                        CreateNewContainer(type, maxWeight, height, width, containerWeight, cargoName);
                        return;
                    }

                    try
                    {
                        newContainer = new CoolContainer(
                            maxWeight.Value, height.Value, width.Value, containerWeight.Value, temperature.Value, cargo
                        );
                        _containers.Add(newContainer);
                    }
                    catch (WrongContainerTemperature e)
                    {
                        Console.WriteLine(e.Message);
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        return;
                    }
                }
                break;
            case 'L':
                newContainer = new LiquidContainer(
                    maxWeight.Value, height.Value, width.Value, containerWeight.Value, cargo
                    );
                _containers.Add(newContainer);
                break;
            case 'G':
                if (pressure == null)
                {
                    try
                    {
                        Console.Write("Enter the pressure of the gas: ");
                        pressure = double.Parse(Console.ReadLine());
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Invalid input. Please enter a valid number for the temperature.");
                        CreateNewContainer(type, maxWeight, height, width, containerWeight, cargoName);
                        return;
                    }
                }
                newContainer = new GazContainer(maxWeight.Value, height.Value, width.Value, containerWeight.Value, pressure.Value, cargo);
                _containers.Add(newContainer);
                
                break;
            default:
                Console.WriteLine("Something went wrong. Please try again.");
                return;
        }
        CreationNotify("New", "Container");
    }

    private static void CreateNewShip()
    {
        Console.Clear();
        CreateNewShip(null, null, null);
    }

    private static void CreateNewShip(string? name, double? maxWeight, int? maxContainers)
    {
        if(name == null)
        {
            try
            {
                Console.Write("Enter the name of the ship: ");
                name = Console.ReadLine();
                if (string.IsNullOrEmpty(name))
                    throw new FormatException();
            }catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter a valid name for the ship.");
                CreateNewShip(null, maxWeight, maxContainers);
                return;
            }
        }
        if(maxWeight == null)
        {
            try
            {
                Console.Write("Enter the maximum weight of the ship: ");
                maxWeight = double.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter a valid number for the weight and number of containers.");
                CreateNewShip(name, null, null);
                return;
            }
        }
        if(maxContainers == null)
        {
            try
            {
                Console.Write("Enter the maximum number of containers: ");
                maxContainers = int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter a valid number for the weight and number of containers.");
                CreateNewShip(name, maxWeight, null);
                return;
            }
        }

        Ship newShip = new Ship(name, maxWeight.Value, maxContainers.Value);
        _ships.Add(newShip);

        CreationNotify("Ship", name);
    }

    private static void CreationNotify(string subject, string name)
    {
        Console.WriteLine("--------------------");
        Console.WriteLine($"{subject} {name} created successfully.");
        Console.WriteLine("--------------------");
        
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
}