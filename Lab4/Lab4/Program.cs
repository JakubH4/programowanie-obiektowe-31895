using System.Text.Json;
using Lab4.Models;

var bikesJson = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "bikes.json"));
var bikes = JsonSerializer.Deserialize<List<Bike>>(bikesJson) ?? new List<Bike>();

var carsJson = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "cars.json"));
var cars = JsonSerializer.Deserialize<List<Car>>(carsJson) ?? new List<Car>();

bool continueApp = true;

void PersistAll()
{
    File.WriteAllText(Path.Combine(Directory.GetCurrentDirectory(), "cars.json"), JsonSerializer.Serialize(cars));
    File.WriteAllText(Path.Combine(Directory.GetCurrentDirectory(), "bikes.json"), JsonSerializer.Serialize(bikes));
}

do
{
    Console.WriteLine("--- MENU ---");
    Console.WriteLine("1. Car list");
    Console.WriteLine("2. New vehicle");
    Console.WriteLine("3. Remove vehicle");
    Console.WriteLine("4. Update vehicle");
    Console.WriteLine("0. Exit");
    
    var option = Console.ReadKey().KeyChar;
    Console.WriteLine();

    switch (option)
    {
        case '0':
            Console.Clear();
            Console.WriteLine("Bye bye...");
            continueApp = false;
            break;
        case '1':
            Console.Clear();
            Console.WriteLine("-- Cars --");
            for (int i = 0; i < cars.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {cars[i].Model} ({cars[i].Year}) - {cars[i].Engine}");
            }
            Console.WriteLine("-- Bikes --");
            for (int i = 0; i < bikes.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {bikes[i].BikeType} - {bikes[i].Engine}");
            }
            
            Console.WriteLine();
            break;
        case '2':
            Console.Clear();
            AddNewVehicle();
            PersistAll();
            break;
        case '3':
            Console.Clear();
            RemoveVehicle();
            PersistAll();
            break;
        case '4':
            Console.Clear();
            UpdateVehicle();
            PersistAll();
            break;
        default:
            Console.WriteLine("Invalid option");
            break;
    }
} while (continueApp);

void RemoveVehicle()
{
    Console.WriteLine("--- REMOVE ---");
    Console.WriteLine("1. Car");
    Console.WriteLine("2. Bike");
    var option = Console.ReadKey().KeyChar;
    Console.WriteLine();

    if (option == '2')
    {
        RemoveBike();
    }
    else if (option == '1')
    {
        RemoveCar();
    }
    else
    {
        Console.WriteLine("Invalid option");
    }
}

void RemoveBike()
{
    if (bikes.Count == 0)
    {
        Console.WriteLine("No bikes to remove.");
        return;
    }

    for (int i = 0; i < bikes.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {bikes[i].BikeType} - {bikes[i].Engine}");
    }

    Console.WriteLine("Select bike number to remove:");
    if (!int.TryParse(Console.ReadLine(), out int index) || index < 1 || index > bikes.Count)
    {
        Console.WriteLine("Invalid selection");
        return;
    }

    bikes.RemoveAt(index - 1);
    Console.WriteLine("Bike removed.");
}

void RemoveCar()
{
    if (cars.Count == 0)
    {
        Console.WriteLine("No cars to remove.");
        return;
    }

    for (int i = 0; i < cars.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {cars[i].Model} ({cars[i].Year}) - {cars[i].Engine}");
    }

    Console.WriteLine("Select car number to remove:");
    if (!int.TryParse(Console.ReadLine(), out int index) || index < 1 || index > cars.Count)
    {
        Console.WriteLine("Invalid selection");
        return;
    }

    cars.RemoveAt(index - 1);
    Console.WriteLine("Car removed.");
}

void AddNewVehicle()
{
    Console.WriteLine("1 for car, 2 for bike: ");
    
    var option = Console.ReadKey().KeyChar;
    Console.WriteLine();

    if (option == '2')
    {
        AddNewBike();
    }
    else if (option == '1')
    {
        AddNewCar();
    }
    else
    {
        Console.WriteLine("Invalid option");
    }
}

void AddNewBike()
{
    Console.WriteLine("Engine: ");
    var engine = Console.ReadLine();
    
    Console.WriteLine("Bike type: ");
    var bikeType = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(bikeType) || string.IsNullOrWhiteSpace(engine))
    {
        Console.WriteLine("Invalid model or bike type");
        return;
    }

    var bike = new Bike(engine, bikeType);
    bikes.Add(bike);
    Console.WriteLine("Bike added.");
}

void AddNewCar()
{
    Console.WriteLine("Model: ");
    var model = Console.ReadLine();
    
    Console.WriteLine("Engine: ");
    var engine = Console.ReadLine();
    
    Console.WriteLine("Year: ");
    var success = int.TryParse(Console.ReadLine(), out int year);

    if (string.IsNullOrWhiteSpace(model) || string.IsNullOrWhiteSpace(engine) || !success)
    {
        Console.WriteLine("Invalid model, engine or year");
        return;
    }

    var car = new Car(engine, model, year);
    cars.Add(car);
    Console.WriteLine("Car added.");
}

void UpdateVehicle()
{
    Console.WriteLine("--- UPDATE ---");
    Console.WriteLine("1. Car");
    Console.WriteLine("2. Bike");
    var option = Console.ReadKey().KeyChar;
    Console.WriteLine();

    if (option == '2')
    {
        UpdateBike();
    }
    else if (option == '1')
    {
        UpdateCar();
    }
    else
    {
        Console.WriteLine("Invalid option");
    }
}

void UpdateBike()
{
    if (bikes.Count == 0)
    {
        Console.WriteLine("No bikes to update.");
        return;
    }

    for (int i = 0; i < bikes.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {bikes[i].BikeType} - {bikes[i].Engine}");
    }

    Console.WriteLine("Select bike number to update:");
    if (!int.TryParse(Console.ReadLine(), out int index) || index < 1 || index > bikes.Count)
    {
        Console.WriteLine("Invalid selection");
        return;
    }

    var bike = bikes[index - 1];
    Console.WriteLine($"Current engine: {bike.Engine}. New engine (leave empty to keep):");
    var newEngine = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(newEngine)) bike.Engine = newEngine;

    Console.WriteLine($"Current bike type: {bike.BikeType}. New bike type (leave empty to keep):");
    var newType = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(newType)) bike.BikeType = newType;

    Console.WriteLine("Bike updated.");
}

void UpdateCar()
{
    if (cars.Count == 0)
    {
        Console.WriteLine("No cars to update.");
        return;
    }

    for (int i = 0; i < cars.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {cars[i].Model} ({cars[i].Year}) - {cars[i].Engine}");
    }

    Console.WriteLine("Select car number to update:");
    if (!int.TryParse(Console.ReadLine(), out int index) || index < 1 || index > cars.Count)
    {
        Console.WriteLine("Invalid selection");
        return;
    }

    var car = cars[index - 1];
    Console.WriteLine($"Current model: {car.Model}. New model (leave empty to keep):");
    var newModel = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(newModel)) car.Model = newModel;

    Console.WriteLine($"Current engine: {car.Engine}. New engine (leave empty to keep):");
    var newEngine = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(newEngine)) car.Engine = newEngine;

    Console.WriteLine($"Current year: {car.Year}. New year (leave empty to keep):");
    var yearInput = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(yearInput) && int.TryParse(yearInput, out int newYear))
    {
        try
        {
            car.Year = newYear;
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine($"Invalid year: {ex.Message}");
        }
    }

    Console.WriteLine("Car updated.");
}