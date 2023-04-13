Console.WriteLine("");

IXmlService _xmlService = new JsonToXmlAdapter();
_xmlService.Serialize("Message - Serialized using Adapter");


interface IXmlService
{
    void Serialize(string message);
}

class JsonSerializer
{
    public void Serialize(string message)
    {
        Console.WriteLine("Json Serialized : " + message);
    }
}

class JsonToXmlAdapter : IXmlService
{
    private JsonSerializer _jsonSerializer = new JsonSerializer();

    public void Serialize(string message)
    {
        _jsonSerializer.Serialize(message);
    }
}

