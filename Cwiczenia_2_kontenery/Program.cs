using Cwiczenia_2_kontenery.Classes;

public class Program
{
    private static List<Cargo> _coolCargo = new List<Cargo>();
    private static List<Cargo> _liquidCargo = new List<Cargo>();
    private static List<Cargo> _gazCargo = new List<Cargo>();

    private static List<Container> _containers = new List<Container>();
    private static List<Ship> _ships = new List<Ship>();

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
            }

            Console.WriteLine("5. Exit");

            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    CreateNewShip();
                    break;
                case "2":
                    Console.WriteLine("You selected Option 2");
                    if (_ships.Count == 0) break;
                    break;
                case "3":
                    Console.WriteLine("You selected Option 2");
                    if (_ships.Count == 0) break;
                    break;
                case "4":
                    Console.WriteLine("You selected Option 2");
                    if (_ships.Count == 0) break;
                    break;
                case "5":
                    Console.WriteLine("Exiting...");
                    return;
                default:
                    Console.WriteLine("Invalid option, please try again.");
                    break;
            }
            Console.Clear();
        }
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
            Console.Write("Enter the name of the ship: "); 
            name = Console.ReadLine();
        }
        if(maxWeight == null)
        {
            try
            {
                maxWeight = AskMaxWeight();
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

        Console.WriteLine($"Ship {name} created successfully.");
       
    }

    private static double AskMaxWeight()
    {
        Console.Write("Enter the maximum weight of the ship: ");
        double maxWeight = double.Parse(Console.ReadLine());
        return maxWeight;
    }
}
