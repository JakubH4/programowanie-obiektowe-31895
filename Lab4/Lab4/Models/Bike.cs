namespace Lab4.Models;

public class Bike : Vehicle
{
    public string BikeType { get; set; }

    public Bike(string engine, string bikeType) : base(engine)
    {
        this.BikeType = bikeType;
    }

    public override void Start()
    {
        Console.WriteLine("Unlocked!");
         base.Start();
    }
}