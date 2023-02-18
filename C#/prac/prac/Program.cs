using System;

interface IMath
{
    int Max();
    int Min();
    float Avg();
    bool Search(int valueToSearch);
}


class Array : IMath
{ 
    public void createList()
    {
        int num = new();

        for (int i = 0; i < Values.Capacity; i++)
        {
            Console.WriteLine("Enter num you want to add: ");
            num = Int32.Parse(Console.ReadLine());

            Values[i] = num;
        }
    }

    public void printAll()
    {
        Console.WriteLine("List elements : ");
        for (int i = 0; i < Values.Capacity; i++)
        {
            Console.WriteLine($"{i} - {Values[i]}");
        }
    }

    public int Max()
    {
        int max = new();

        max = Values[0];

        for (int i = 0; i < Values.Capacity; i++)
        {
            if (max < Values[i])
            {
                max = Values[i];
            }
        }

        return max;
    }

    public int Min()
    {
        int min = new();

        min = Values[0];

        for (int i = 0; i < Values.Capacity; i++)
        {
            if (min > Values[i])
            {
                min = Values[i];
            }
        }

        return min;
    }

    public float Avg()
    {
        int total = 0;
        float avg = new();

        for (int i = 0; i < Values.Capacity; i++)
        {
            total += Values[i];
        }

        avg = total / Values.Capacity;

        return avg;
    }

    public bool Search(int valueToSearch)
    {
        for (int i = 0; i < Values.Count; i++)
        {
            if ( valueToSearch == Values[i]) { return true; }
        }

        return false;
    }

    public List<int> Values = new();
}
