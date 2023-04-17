Console.WriteLine("");

string tmp_name;
int tmp_checker;
bool tmp_type = false;
bool key = false;

AbstractionOwner owner = new AbstractionOwner();

Console.WriteLine("Enter Name of Pet: ");
tmp_name = Console.ReadLine();

while(key != true)
{
    Console.WriteLine("Enter 0 if it is Cat and 1 if it is Dog: ");
    tmp_checker = Int32.Parse(Console.ReadLine().ToString());

    switch (tmp_checker)
    {
        case 0:
            tmp_type = true;
            key = true;
            break;
        case 1:
            tmp_type = false;
            key = true;
            break;
        default:
            Console.WriteLine("Wrong Entered Value Try Again\n\n");
            key = false;
            break;
    }
}

if (tmp_type)
{
    owner.Animal = new Cat(tmp_name);
}
else
{
    owner.Animal = new Dog(tmp_name);
}

Console.Clear();

key = false;
while(key != true)
{
    Console.WriteLine($"Enter 1 if you want to feed {owner.Animal.Name}\n" +
    $"Enter 2 if you want {owner.Animal.Name} make sound: \n");
    tmp_checker = Int32.Parse(Console.ReadLine().ToString());

    switch (tmp_checker)
    {
        case 1:
            owner.Feed();
            key = true;
            break;
        case 2:
            owner.CallPet();
            key = true;
            break;
        default:
            Console.WriteLine("Wrong Entered Value Try Again\n\n");
            key = false;
            break;
    }
}

public class AbstractionOwner
{
    protected Animal animal;

    public Animal Animal
    {
        get { return animal; }
        set { animal = value; }
    }

    public virtual void Feed()
    {
        animal.Eat();
    }

    public virtual void CallPet()
    {
        animal.MakeSound();
    }
}

public abstract class Animal
{
    public string Name { get; set; }
    public int Nutrition { get; set; }

    public abstract void Eat();
    public abstract void MakeSound();
}

public class Dog : Animal
{
    public string Name { get; set; }
    public int Nutrition { get; set; }

    public Dog( string name )
    {
        this.Name = name;
    }

    public override void Eat()
    {
        Console.WriteLine($"Dog {this.Name} Feeded");
        this.Nutrition += 35;
    }

    public override void MakeSound()
    {
        Console.WriteLine($"Dog {this.Name} Making 'Ruff Ruff'");
    }
}

public class Cat : Animal
{
    public string Name { get; set; }
    public int Nutrition { get; set; }

    public Cat( string name)
    {
        this.Name = name;
    }

    public override void Eat()
    {
        Console.WriteLine($"Cat {this.Name} Feeded");
        this.Nutrition += 15;
    }

    public override void MakeSound()
    {
        Console.WriteLine($"Cat {this.Name} Making 'Meow Meow'");
    }
}