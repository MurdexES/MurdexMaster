Console.WriteLine(" ");

Array arr = new();

arr.createList();

arr.printAll();

Console.WriteLine("Less : " + arr.Less(4));
Console.WriteLine("Greater : " + arr.Greater(4));

Console.WriteLine("Distinct Count : " + arr.CountDistinct());
Console.WriteLine("Equal count : " + arr.EqualToValue(4));

arr.ShowEven();
arr.ShowOdd();

interface ICalc
{
    int Less(int valueToCompare);

    int Greater(int valueToCompare);
}

interface IOutput2
{
    void ShowEven();
    void ShowOdd();

}

interface ICalc2
{
    int CountDistinct();
    int EqualToValue(int valueToCompare);
}

class Array : ICalc, IOutput2, ICalc2
{
    public void createList()
    {
        int num = new();

        for (int i = 0; i < Values.Count; i++)
        {
            Console.WriteLine("Enter num you want to add: ");
            num = Int32.Parse(Console.ReadLine());

            Values[i] = num;
        }
    }

    public void printAll()
    {
        Console.WriteLine("List elements : ");
        for (int i = 0; i < Values.Count; i++)
        {
            Console.WriteLine($"{i} - {Values[i]}");
        }
    }

    public int Less(int valueToCompare)
    {

        for (int i = 0; i < Values.Count; i++)
        {
            if (Values[i] == valueToCompare)
            {
                if (i > 0)
                {
                    return i;
                }
                else
                {
                    return 0;
                }
            }
        }

        return 0;
    }

    public int Greater(int valueToCompare)
    {
        for (int i = 0; i < Values.Count; i++)
        {
            if (Values[i] == valueToCompare)
            {
                if (i > 0)
                {
                    return Values.Count - (i + 1);
                }
                else
                {
                    return 0;
                }
            }
        }
        return 0;
    }

    public void ShowEven()
    {
        Console.WriteLine("All Evens : ");

        for (int i = 0; i < Values.Count; i++)
        {
            if (Values[i] % 2 == 0)
            {
                Console.WriteLine(Values[i]);
            }
        }
    }

    public void ShowOdd()
    {
        Console.WriteLine("All Odds : ");

        for (int i = 0; i < Values.Count; i++)
        {
            if (Values[i] % 2 != 0)
            {
                Console.WriteLine(Values[i]);
            }
        }
    }

    public int CountDistinct()
    {
        int count = new();
        int count_tmp = new();

        for (int i = 0; i < Values.Count; i++)
        {
            for (int j = 0; j < Values.Count; j++)
            {
                if (Values[i] == Values[j])
                {
                    count_tmp++;
                }
            }

            if (count_tmp == 1)
            {
                count++;
            }
        }

        return count;
    }

    public int EqualToValue(int valueToCompare)
    {
        int count = new();

        for (int i = 0; i < Values.Count; i++)
        {
            if (Values[i] == valueToCompare)
            {
                count++;
            }
        }

        return count;
    }

    List<int> Values = new();
}
