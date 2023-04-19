using System;

Console.WriteLine("");

Car sportsCar = new SportsCar();
sportsCar.CreateCar();

Console.WriteLine("");

Car coupeCar = new CoupeCar();
coupeCar.CreateCar();

Console.WriteLine("");

Car muscleCar = new MuscleCar();
muscleCar.CreateCar();


public abstract class Car
{
    public void CreateCar()
    {
        InstallEngine();
        InstallWheels();
        PaintCar();
        Console.WriteLine("Car is complete!");
    }

    public abstract void InstallEngine();

    public abstract void InstallWheels();

    public virtual void PaintCar()
    {
        Console.WriteLine("Car is Painted");
    }
}

public class SportsCar : Car
{
    public override void InstallEngine()
    {
        Console.WriteLine("Installing a sports car engine");
    }

    public override void InstallWheels()
    {
        Console.WriteLine("Installing sports car wheels");
    }

    public override void PaintCar()
    {
        Console.WriteLine("Painting the sports car with a sportic color");
    }
}

public class CoupeCar : Car
{
    public override void InstallEngine()
    {
        Console.WriteLine("Installed a coupe car engine");
    }

    public override void InstallWheels()
    {
        Console.WriteLine("Installed coupe car wheels");
    }

    public override void PaintCar()
    {
        Console.WriteLine("Painted the coupe car");
    }
}

public class MuscleCar : Car
{
    public override void InstallEngine()
    {
        Console.WriteLine("Installed a muscle car engine");
    }

    public override void InstallWheels()
    {
        Console.WriteLine("Installed muscle car wheels");
    }

    public override void PaintCar()
    {
        Console.WriteLine("Painted the muscle car in classic color");
    }
}
