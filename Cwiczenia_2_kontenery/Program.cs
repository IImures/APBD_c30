using Cwiczenia_2_kontenery.Classes;
using Cwiczenia_2_kontenery.Classes.Data;
using Cwiczenia_2_kontenery.Classes.Service;
using Cwiczenia_2_kontenery.Exceptions;

namespace Cwiczenia_2_kontenery;

public class Program
{

    private static DataManager dataManager;
    private static MenuService menuService;
    
    public static void Main(string[] args)
    {
        dataManager = new DataManager();
        menuService = new MenuService(dataManager);

        while (true)
        {
            Console.WriteLine("--------------------");
            if(!dataManager.IsCargoAvailable())
                Console.WriteLine("No Cargo available.");
            else
            {
                Console.WriteLine("Cargo available:");
                dataManager.PrintAllCargo();
            }
            Console.WriteLine("--------------------");
            if (dataManager.ContainerCount == 0)
            {
                Console.WriteLine("No Containers available.");
            }
            else
            {
                Console.WriteLine(dataManager.ContainerCount > 1 ? "Containers available:" : "Container available:");
                dataManager.PrintAllContainers();
            }
            Console.WriteLine("--------------------");
            if (dataManager.ShipCount == 0)
            {
                Console.WriteLine("No Ships available.");
            }
            else
            {
                Console.WriteLine(dataManager.ShipCount > 1 ? "Ships available:" : "Ship available: ");
                dataManager.PrintAllShips();
            }
            Console.WriteLine("--------------------");
            Console.WriteLine("Please select an option:");
            Console.WriteLine("1. Add Ship");
            if (dataManager.ShipCount > 0)
            {
                Console.WriteLine("2. Configure Ship");
                Console.WriteLine("3. Add Container");
                if (dataManager.ContainerCount > 0)
                    Console.WriteLine("4. Configure Container");
                Console.WriteLine("5. Add Cargo");
            }

            Console.WriteLine("6. Exit");

            string? userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1": //"1. Add Ship"
                    menuService.CreateNewShip();
                    break;
                
                case "2": //"2. Configure Ship"
                    if (dataManager.ShipCount == 0) break;
                    ConfigureShip();
                    break;
                
                case "3": //"3. Add Container"
                    if (dataManager.ShipCount == 0) break;
                    menuService.CreateNewContainer();
                    break;
                
                case "4": //"4. Load Container"
                    if (dataManager.ShipCount == 0) break;
                    ConfigureContainer();
                    break;
                
                case "5": //"5. Add Cargo"
                    if (dataManager.ShipCount == 0) break;
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
    
    private static void ConfigureContainer()
    {
        Console.Clear();
        Console.WriteLine("Enter option:");
        Console.WriteLine("1. Load Container");
        Console.WriteLine("2. Unload Container");
        Console.WriteLine("3. Delete Container");
        Console.WriteLine("4. Exit");
        string? userInput = Console.ReadLine();
        switch (userInput)
        {
            case "1":
                menuService.LoadContainer();
                break;
            case "2":
                menuService.UnloadContainer();
                break;
            case "3":
                menuService.DeleteContainer();
                break;
            case "4":
                return;
            default:
                Console.WriteLine("Invalid option, please try again. Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
                ConfigureShip();
                break;
        }
    }

    private static void ConfigureShip()
    {
        Console.Clear();
        Console.WriteLine("Enter option:");
        Console.WriteLine("1. Load Container");
        Console.WriteLine("2. Unload Container");
        Console.WriteLine("3. Delete Ship");
        Console.WriteLine("4. Exit");
        string? userInput = Console.ReadLine();
        switch (userInput)
        {
            case "1":
                menuService.LoadShip();
                break;
            case "2":
                menuService.UnloadShip();
                break;
            case "3":
                menuService.DeleteShip();
                break;
            case "4":
                return;
            default:
                Console.WriteLine("Invalid option, please try again. Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
                ConfigureShip();
                break;
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
                menuService.CreateNewCoolCargo();
                break;
            case "2":
                menuService.CreateNewGazCargo();
                break;
            case "3":
                menuService.CreateNewLiquidCargo();
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
}