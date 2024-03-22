using Cwiczenia_2_kontenery.Classes.Data;
using Cwiczenia_2_kontenery.Exceptions;

namespace Cwiczenia_2_kontenery.Classes.Service;

public class MenuService
{
  
    private DataManager _dataManager;
    
    public MenuService(DataManager dataManager)
    {
        _dataManager = dataManager;
    }
    
    
    public void CreateNewCoolCargo()
    {
        Console.Clear();
        CreateNewCoolCargo(null, null);
    }

    private static string AskUserForString(string? message)
    {
        try
        {
            string? userInput;
            if (string.IsNullOrEmpty(message))
                Console.Write("Your input:");
            else
                Console.Write(message);
            userInput = Console.ReadLine();
            if (string.IsNullOrEmpty(userInput))
                throw new FormatException();
            return userInput;
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input. Press any key to try again...");
            Console.ReadKey();
            Console.Clear();
            return AskUserForString(message);
        }
    }

    private double AskUserForDouble(string? message)
    {
        try
        {
            double userInput;
            if (string.IsNullOrEmpty(message))
                Console.Write("Your input:");
            else
                Console.Write(message);
            userInput = Double.Parse(Console.ReadLine());
            return userInput;
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input. Press any key to try again...");
            Console.ReadKey();
            Console.Clear();
            return AskUserForDouble(message);
        }
    }

    private int AskUserForInt(string? message)
    {
        try
        {
            int userInput;
            if (string.IsNullOrEmpty(message))
                Console.Write("Your input:");
            else
                Console.Write(message);
            userInput = int.Parse(Console.ReadLine());
            return userInput;
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input. Press any key to try again...");
            Console.ReadKey();
            Console.Clear();
            return AskUserForInt(message);
        }
    }

    private void CreateNewCoolCargo(string? name, double? temperature)
    {
        if(name == null)
            name = AskUserForString("Enter the name of the cargo: ");
        if (temperature == null)
            temperature = AskUserForDouble("Enter the temperature of the cargo: ");
        Cargo newCargo = new Cargo(name, temperature.Value);
        _dataManager.AddCoolCargo(newCargo);
        CreationNotify("Cool Cargo", newCargo.Name);
    }
    
    public void CreateNewGazCargo()
    {
        Console.Clear();
        CreateNewGazCargo(null);
    }
    
    private void CreateNewGazCargo(string? name)
    {
        if(name == null)
            name = AskUserForString("Enter the name of the cargo: ");
        Cargo newCargo = new Cargo(name);
        _dataManager.AddGazCargo(newCargo);
        CreationNotify("Gaz Cargo", newCargo.Name);
    }
    
    public void CreateNewLiquidCargo()
    {
        Console.Clear();
        CreateNewLiquidCargo(null, null);
    }
    
    private void CreateNewLiquidCargo(string? name, bool? isHazardous)
    {
        if(name == null)
            name = AskUserForString("Enter the name of the cargo: ");
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
        _dataManager.AddLiquidCargo(newCargo);
        CreationNotify("Liquid Cargo", newCargo.Name);
    }
    public void CreateNewContainer()
    {
        Console.Clear();
        CreateNewContainer(null, null, null, null, null, null); 
    }

    private void CreateNewContainer(char? type, double? maxWeight, double? height, double? width,
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
            maxWeight = AskUserForDouble("Enter the maximum cargo weight for the container: ");
        if (height == null)
            height = AskUserForDouble("Enter the height of the container: ");
        if (width == null)
            width = AskUserForDouble("Enter the width of the container: ");
        if (containerWeight == null)
            containerWeight = AskUserForDouble("Enter the weight of the container: ");

        Cargo cargo = null;
        if (cargoName == null)
        {
            try
            {
                if (type == 'C')
                {
                    _dataManager.PrintCoolContainers();
                }
                else if (type == 'L')
                {
                    _dataManager.PrintLiquidContainers();
                }
                else if (type == 'G')
                {
                    _dataManager.PrintGazContainers();
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

            cargo = _dataManager.FindCargo(cargoName);
            if (cargo == null) 
            { 
                Console.WriteLine("Cargo not found. Please enter a valid cargo name. Try again. Press any key to continue..."); 
                Console.ReadKey(); 
                return;
            }
        }
        
        
        Container newContainer;
        switch (type)
        {
            case 'C':
                if(temperature==null)
                    temperature = AskUserForDouble("Enter the temperature of the container: ");

                try {
                    newContainer = new CoolContainer(
                        maxWeight.Value, height.Value, width.Value, containerWeight.Value, temperature.Value, cargo
                        );
                }catch (WrongContainerTemperature e)
                { 
                    Console.WriteLine(e.Message); 
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    return;
                }
                break;
            case 'L':
                newContainer = new LiquidContainer(
                    maxWeight.Value, height.Value, width.Value, containerWeight.Value, cargo
                    );
                break;
            case 'G':
                if (pressure == null)
                    pressure = AskUserForDouble("Enter the pressure of the gas: ");
                newContainer = new GazContainer(
                    maxWeight.Value, height.Value, width.Value, containerWeight.Value, pressure.Value, cargo
                    );
                break;
            default:
                Console.WriteLine("Something went wrong. Please try again.");
                return;
        }
        _dataManager.AddContainer(newContainer);
        CreationNotify("New", "Container");
    }

    public void CreateNewShip()
    {
        Console.Clear();
        CreateNewShip(null, null, null);
    }

    private void CreateNewShip(string? name, double? maxWeight, int? maxContainers)
    {
        name ??= AskUserForString("Enter the name of the ship: ");
        maxWeight ??= AskUserForDouble("Enter the maximum weight of the ship: ");
        maxContainers ??= AskUserForInt("Enter the maximum number of containers: ");

        Ship newShip = new Ship(name, maxWeight.Value, maxContainers.Value);
        _dataManager.AddShip(newShip);

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

    public void LoadShip()
    {
        _dataManager.PrintAllShips();
        Ship selectedShip = _dataManager.GetShipById(AskUserForInt("Choose your ship(enter number in id): "));
        if (selectedShip == null)
        {
            Console.WriteLine("No ship was found. Press any key to continue...");
            Console.ReadKey();
            return;
        }
        _dataManager.PrintAllContainers();
        Container selectedContainer = _dataManager.GetContainerById(AskUserForInt("Choose your container(enter its id): "));
        if (selectedContainer == null)
        {
            Console.WriteLine("No container was found. Press any key to continue...");
            Console.ReadKey();
            return;
        }

        try
        {
            selectedShip.AddContainer(selectedContainer);
            _dataManager.DeleteContainer(selectedContainer);
        }
        catch (OverfillException e)
        {
            Console.WriteLine(e.Message);
            Console.ReadKey();
        }
        
        
        Console.WriteLine("Container was loaded. Press any key to continue...");
        Console.ReadKey();
    }
    public void UnloadShip()
    {
        _dataManager.PrintAllShips();
        Ship selectedShip = _dataManager.GetShipById(AskUserForInt("Choose your ship(enter number in id): "));
        if (selectedShip == null)
        {
            Console.WriteLine("No ship was found");
            return;
        }

        foreach (Container container in selectedShip.Containers)
        {
            Console.WriteLine(container);
        }
        int containerId = AskUserForInt("Choose your container(enter its id): ");
        
        foreach (Container container in selectedShip.Containers)
        {
            if (container.Id == containerId)
            {
                selectedShip.Unload(containerId);
                _dataManager.AddContainer(container);
                Console.WriteLine("Container was unloaded. Press any key to continue...");
                Console.ReadKey();
                return;
            }
        }
        Console.WriteLine("Container wasn't unloaded. Press any key to continue...");
        Console.ReadKey();
    }

    public void DeleteShip()
    {
        _dataManager.PrintAllShips();
        _dataManager.DeleteShipById(AskUserForInt("Choose your ship(enter number in id): "));
    }

    public void LoadContainer()
    {
        _dataManager.PrintAllContainers();
        Container selectedContainer =
            _dataManager.FindContainerById(AskUserForInt("Enter container id(only number): "));
        if (selectedContainer == null)
        {
            Console.WriteLine("Container wasn't selected.Press any key to continue");
            Console.ReadKey();
            return;
        }

        try
        {
            selectedContainer.Load(AskUserForDouble("Enter weight to load: "));
            Console.WriteLine("Container was loaded. Press any key to continue...");
            Console.ReadKey();
        }
        catch (Exception e)
        {
            Console.WriteLine($"Exception: {e.Message}");
            Console.WriteLine("Container wasn't loaded. Press any key to continue...");
            Console.ReadKey();
        }
    }
    
    public void UnloadContainer()
    {
        _dataManager.PrintAllContainers();
        Container selectedContainer =
            _dataManager.FindContainerById(AskUserForInt("Enter container id(only number): "));
        if (selectedContainer == null)
        {
            Console.WriteLine("Container wasn't selected.Press any key to continue");
            Console.ReadKey();
            return;
        }

        try
        {
            selectedContainer.Unload(AskUserForDouble("Enter weight to unload: "));
            Console.WriteLine("Container was unloaded. Press any key to continue...");
            Console.ReadKey();
        }
        catch (Exception e)
        {
            Console.WriteLine($"Exception: {e.Message}");            
            Console.WriteLine("Container wasn't unloaded. Press any key to continue...");
            Console.ReadKey();
        }
    }
    
    public void DeleteContainer()
    {
        _dataManager.PrintAllContainers();
        Container selectedContainer =
            _dataManager.FindContainerById(AskUserForInt("Enter container id(only number): "));
        if (selectedContainer == null)
        {
            Console.WriteLine("Container wasn't selected.Press any key to continue");
            Console.ReadKey();
            return;
        }

        try
        {
           _dataManager.DeleteContainer(selectedContainer);
           Console.WriteLine("Container was deleted. Press any key to continue...");
           Console.ReadKey();
        }
        catch (Exception e)
        {
            Console.WriteLine($"Exception: {e.Message}");
            Console.WriteLine("Container wasn't deleted. Press any key to continue...");
            Console.ReadKey();
        }
    }
}