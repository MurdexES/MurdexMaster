using System.ComponentModel;

int num = new();

// Task 1

Console.WriteLine("Enter number from 1 - 100: ");
num = Int32.Parse(Console.ReadLine());

if (num > 1 && num < 100)
{
    if (num % 3 == 0 && num % 5 != 0)
    {
        Console.WriteLine("Fizz");
    }

    else if (num % 5 == 0 && num % 3 != 0)
    {
        Console.WriteLine("Buzz");
    }

    else if (num % 3 == 0 && num % 5 == 0)
    {
        Console.WriteLine("Fizz Buzz");
    }

    else { Console.WriteLine(num); }
}

else { Console.WriteLine("Wrong Number"); }

// Task 2

int percent = new();

Console.WriteLine("Enter Number: ");
num = Int32.Parse(Console.ReadLine());

Console.WriteLine("Enter Percent: ");
percent = Int32.Parse(Console.ReadLine());

num = num * (percent / 100);
Console.WriteLine(num);

//Task 3

int num_res = new();
int k = 1000;

for (int i = 0; i< num; i++) 
{
    num_res += Int32.Parse(Console.ReadLine()) * k;
    k /= 10;
}
//Task 4

List<int> numbers = new List<int>(6);
int number = new();
int kf = 100000;

int first_indx = new();
int second_indx = new();

int tmp = 0;

Console.WriteLine("Enter number with 6-digits : ");
number = Int32.Parse(Console.ReadLine());

if (number >= 100000 && number <= 999999)
{
    for (int i = 0; i < 6; i++)
    {
        numbers[i] = number / kf;
        number = number - (numbers[i] * kf);
        kf /= 10;
    }
}

Console.WriteLine("Index of the first digit: ");
first_indx = Int32.Parse(Console.ReadLine());

Console.WriteLine("Index of the second digit: ");
second_indx = Int32.Parse(Console.ReadLine());

tmp = numbers[first_indx];
numbers[first_indx] = numbers[second_indx];
numbers[second_indx] = tmp;

number = 0;
kf = 100000;

for (int i = 0; i < 6; i++)
{
    number += numbers[i] * kf;
    kf /= 10;
}

Console.WriteLine(number);

//Task 5
int day = new();
int month = new();
int year = new();

Console.WriteLine("Enter date dd:mm:yy - ");
day = Int32.Parse(Console.ReadLine());
month = Int32.Parse(Console.ReadLine());
year = Int32.Parse(Console.ReadLine());

DateTime date = new DateTime(day, month, year);

if ( date.Month == 12 || date.Month < 3)
{
    Console.WriteLine(date.DayOfWeek + " Winter");
}
else if (date.Month >= 3 || date.Month < 6)
{
    Console.WriteLine(date.DayOfWeek + " Spring");
}
else if (date.Month >= 6 || date.Month < 9)
{
    Console.WriteLine(date.DayOfWeek + " Summer");
}
else if (date.Month >= 9 || date.Month < 12)
{
    Console.WriteLine(date.DayOfWeek + " Fall");
}


//Task 6

int temprature = new();
int choice = new();

Console.WriteLine("Enter temprature: ");
temprature = Int32.Parse(Console.ReadLine());

Console.WriteLine("If you want to turn Fahrenheit to Celsius - 1, vice versa - 0 : ");
choice = Int32.Parse(Console.ReadLine());

if ( choice == 1)
{
    temprature = (temprature - 32) * 5 / 9;
    Console.WriteLine($"Temprature in C: {temprature}");
}
else if ( choice == 0)
{
    temprature = temprature * 9 / 5 + 32;
    Console.WriteLine($"Temprature in F: {temprature}");
}
else { Console.WriteLine("Wrong Value");  }

//Task 7

int num1 = new();
int num2 = new();

List<int> list = new List<int>();

Console.WriteLine("Enter first number : ");
num1 = Int32.Parse(Console.ReadLine());

Console.WriteLine("Enter second number : ");
num2 = Int32.Parse(Console.ReadLine());


if (num1 < num2)
{
    for (int i = num1 + 1; i < num2; i++)
    {
        if (i % 2 == 0) { list.Add(i); }
    }
}
else if ( num2 < num1)
{
    for (int i = num2 + 1; i < num1; i++)
    {
        if (i % 2 == 0) { list.Add(i); }
    }
}

Console.WriteLine("All even numbers: \n");
for (int i = 0; i < list.Count; i++)
{
    Console.WriteLine(list[i] + '\n');
}
