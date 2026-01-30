namespace Lab4.Models;

public class Car : Vehicle
{
    private int year;

    public string Model { get; set; }

    public int Year
    {
        get {return year;}
        set
        {
            if (value <= 2000)
            {
                throw new ArgumentOutOfRangeException("Year must be higher than 2000");
            }

            year = value;
        }
    }

    public Car(string engine, string model, int year) : base(engine)
    {
        Model = model;
        Year = year;
    }

    public void ShowMe()
    {
        Console.WriteLine($"Mode: {Model}, Year: {Year}, Engine: {Engine}");
    }
}