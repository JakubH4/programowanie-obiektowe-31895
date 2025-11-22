using System;

Car car1 = new Car(model: "Audi", year: 2023);
Car car2 = new Car(model: "VW", year: 1998);
Car car3 = new Car(model: "Fiat", year: 2011);

car1.ShowMe();
car2.ShowMe();
car3.ShowMe();

var bike1 = new Bike();

StartAnyVehicle(bike1);
StartAnyVehicle(car2);

Console.ReadKey();

void StartAnyVehicle(Vehicle vehicle)
{
    vehicle.Start();
}

class Vehicle
{
    public string Color { get; protected set; }
    public double EngineCapacity { get; set; }

    public void Start()
    {
        Console.WriteLine("Vehicle Started");
    }

    public void Stop()
    {
    }
}

class Bike : Vehicle
{
}

class Car : Vehicle
{
    private string model;
    private int year;

    public Car(string model, int year)
    {
        this.model = model;
        this.year = year;
    }

    public string Model
    {
        get { return model; }
    }

    public int Year
    {
        get { return year; }
        set
        {
            if (value > 0)
            {
                year = value;
            }
        }
    }

    public void ShowMe()
    {
        Console.WriteLine($"Model: {model}, Year: {year}");
    }
}