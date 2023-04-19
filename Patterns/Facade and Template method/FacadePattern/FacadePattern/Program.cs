// Facade interface
public interface ICarFacade
{
    void StartCar();
    void StopCar();
}

// Concrete Facade
public class CarFacade : ICarFacade
{
    private readonly IEngine _engine;
    private readonly ITransmission _transmission;

    public CarFacade(IEngine engine, ITransmission transmission)
    {
        _engine = engine;
        _transmission = transmission;
    }

    public void StartCar()
    {
        _engine.Start();
        _transmission.SetGear(1);
    }

    public void StopCar()
    {
        _transmission.SetGear(0);
        _engine.Stop();
    }
}

// Subsystem classes
public interface IEngine
{
    void Start();
    void Stop();
}

public interface ITransmission
{
    void SetGear(int gear);
}

public class Engine : IEngine
{
    public void Start()
    {
        Console.WriteLine("Starting engine...");
    }

    public void Stop()
    {
        Console.WriteLine("Stopping engine...");
    }
}

public class Transmission : ITransmission
{
    public void SetGear(int gear)
    {
        Console.WriteLine($"Setting gear to {gear}");
    }
}

// Client code
public class Client
{
    public static void Main()
    {
        // Create the subsystem objects
        var engine = new Engine();
        var transmission = new Transmission();

        // Create the facade object, passing in the subsystem objects
        var carFacade = new CarFacade(engine, transmission);

        // Start the car using the facade
        carFacade.StartCar();

        // Stop the car using the facade
        carFacade.StopCar();
    }
}