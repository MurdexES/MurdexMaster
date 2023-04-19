using System;

public abstract class DataImporter
{
    public void ImportData()
    {
        OpenFile();
        ParseFile();
        TransformData();
        LoadData();
        Console.WriteLine("Data imported successfully!");
    }

    protected abstract void OpenFile();

    protected abstract void ParseFile();

    protected virtual void TransformData()
    {
        Console.WriteLine("Data transformation is not required for this file format.");
    }

    protected abstract void LoadData();
}

public class CSVDataImporter : DataImporter
{
    protected override void OpenFile()
    {
        Console.WriteLine("Opening CSV file...");
    }

    protected override void ParseFile()
    {
        Console.WriteLine("Parsing CSV file...");
    }

    protected override void LoadData()
    {
        Console.WriteLine("Loading data into database...");
    }
}

public class XMLDataImporter : DataImporter
{
    protected override void OpenFile()
    {
        Console.WriteLine("Opening XML file...");
    }

    protected override void ParseFile()
    {
        Console.WriteLine("Parsing XML file...");
    }

    protected override void TransformData()
    {
        Console.WriteLine("Transforming XML data into CSV format...");
    }

    protected override void LoadData()
    {
        Console.WriteLine("Loading data into database...");
    }
}

class Program
{
    static void Main(string[] args)
    {
        DataImporter importer = new CSVDataImporter();
        importer.ImportData();

        importer = new XMLDataImporter();
        importer.ImportData();
    }
}
