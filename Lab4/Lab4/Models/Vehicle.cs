namespace Lab4.Models;

public abstract class Vehicle
{
    public bool IsOn{get; private set;}
    
    public string Engine { get; set; }
    
    public Vehicle(string engine)
    {
        Engine = engine;
         
    }

    public virtual void Start()
    {
        Console.WriteLine("Vehicle Started");
        IsOn = true;
    }
    
    /*
    public virtual void Start(int level)
    {
        if (level == 0)
        {
            Console.WriteLine("Vehicle Started");
        IsOn = true;
        }
        throw new Exception("You cannot drive!");
    }
    */

    public void Stop()
    {
        IsOn = false;
    }
}