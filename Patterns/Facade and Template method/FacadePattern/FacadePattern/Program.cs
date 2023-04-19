Console.WriteLine("");

var engine = new Engine();
var car = new CarFacade(engine);

car.StartCar();

car.StopCar();



public interface ICarFacade
{
    void StartCar();
    void StopCar();
}

public interface IEngine
{
    void Start();
    void Stop();
}

public class CarFacade : ICarFacade
{
    private readonly IEngine _engine;

    public CarFacade(IEngine engine)
    {
        _engine = engine;
    }

    public void StartCar()
    {
        _engine.Start();
    }

    public void StopCar()
    {
        _engine.Stop();
    }
}

public class Engine : IEngine
{
    public void Start()
    {
        Console.WriteLine("Engine Started!!!");
    }

    public void Stop()
    {
        Console.WriteLine("Engine Stopped!!!");
    }
}
