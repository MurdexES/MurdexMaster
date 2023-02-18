Console.WriteLine("Enter expression: \n");

List<char> text = Char.Parse(Console.ReadLine());
List<int> list = new List<int>();
List<char> symbols = new List<char>();
int count = new();

for (int i = 0; i < text.Length; i++)
{
    if (text[i] == '+')
    {
        count++;
        symbols.Add('+');
        text.Replace('+', ' ');
    }
    else if (text[i] == '-')
    {
        count++;
        symbols.Add('-');
        text.Replace('-', ' ');
    }
}
Console.WriteLine(text);

string[] strings = text.Split();
int first = Int32.Parse(strings[0]);

for (int i = 0; i < strings.Length - 1; i++)
{
    if (symbols[i] == '+')
    {
        first += Int32.Parse(strings[i + 1]);
    }
    else if (symbols[i] == '-') 
    {
        first -= Int32.Parse(strings[i + 1]);
    }
}

Console.WriteLine(first);
