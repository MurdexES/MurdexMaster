//SOLID

#region 1 - Single Responsibility Principle
public class Car // Класс Car Занимветься только собой
{
    public void Drive() { } // Вождение Не Должен Быть в классе Car

    public void FixEngine() { } // Починка Двигателя
}

public class Driver // Класс Driver Занимаеться только вождением
{
    public void Drive(Car car)
    {
        car.Drive();
    }
}
#endregion

#region 2 - Open-Closed Principle
public abstract class Car // Класс Car являеться абстрактным и позволяет его дополнять
{
    public string Make { get; set; }
    public string Model { get; set; }
    public double Speed { get; set; }

    //Виртуальные методы
    public virtual void Accelerate(double amount) { }

    public virtual void Brake(double amount) { }
}

public class SportsCar : Car //Класс SportsCar имплементируеться от класса Car и дополняет его
{
    //Реализация методов в конкретном классе
    public override void Accelerate(double amount) { }

    public override void Brake(double amount) { }

    public void Drift() { }
}

#endregion

#region 3 - Liskov Substitution Principle
public class Car // Класс Car являеться суперклассом
{
    public virtual void StartEngine() { }

    public virtual void Drive() { }
}

public class ElectricCar : Car // ElectricCar Подкласс класса Car
{
    public override void StartEngine() { }

    public override void Drive() { }
}

public class GasolineCar : Car // GasolineCar Подкласс класса Car
{
    public override void StartEngine() { }

    public override void Drive() { }
}

public class Driver
{
    public Car car = new ElectricCar(); // Тут вместо суперкласса можно подставить люьбой его покласс
    public void DriveCar(Car car)
    {
        car.StartEngine();
        car.Drive();
    }
}

#endregion

#region 4 - Interface Segregation Principle
public interface IEngine
{
    void Start();
    void Stop();
}

public interface IWheel
{
    void UseBreaks();
}

public interface ICar
{
    void Drive();
    void Stop();
}

public class Engine : IEngine
{
    public void Start()
    {
        Console.WriteLine("Started engine!!!");
    }

    public void Stop()
    {
        Console.WriteLine("Stopped engine!!!");
    }
}

public class Wheel : IWheel
{
    public void UseBreaks()
    {
        Console.WriteLine("Using breaks!!!");
    }
}

public class Car : ICar // Класс Car использует только те интерфейсы которые ему нужны благодаря делению всего на маленькие интерфейсы такие как IEngine и IWheel
{
    private readonly IEngine _engine;
    private readonly IWheel _wheel;

    public Car(IEngine engine, IWheel wheel)
    {
        _engine = engine;
        _wheel = wheel;
    }

    public void Drive()
    {
        _engine.Start();
    }

    public void Stop()
    {
        _engine.Stop();
        _wheel.UseBreaks();
    }
}

#endregion

#region 5 - Dependency Inversion Principle
public interface IEngine
{
    void Start();
    void Stop();
}

public interface IWheel
{
    void UseBreaks();
}

public interface ICar
{
    void Drive();
    void Stop();
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

public class Wheel : IWheel
{
    public void UseBreaks()
    {
        Console.WriteLine("Using breaks!!!");
    }
}

public class Car : ICar // Класс Car имплементируеться от ICar и зависит от него
{
    private readonly IEngine _engine;
    private readonly IWheel _wheel;

    public Car(IEngine engine, IWheel wheel)
    {
        _engine = engine;
        _wheel = wheel;
    }

    public void Drive()
    {
        _engine.Start();
    }

    public void Stop()
    {
        _engine.Stop();
        _wheel.UseBreaks();
    }
}

public class CarController // Класс CarController тоже использует ICar и тоже зависит от него что позволяет легко менять реализации ICar в CarController и тем самым CarController не зависит от определеного класса
{
    private readonly ICar _car;

    public CarController(ICar car)
    {
        _car = car;
    }

    public void DriveCar()
    {
        _car.Drive();
    }

    public void StopCar()
    {
        _car.Stop();
    }
}

#endregion
