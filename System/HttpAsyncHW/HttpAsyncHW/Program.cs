using Newtonsoft.Json;
using System.Linq;


HttpClient client = new HttpClient();
string apiUrl = "https://www.carqueryapi.com/api/0.3/?callback=?&cmd=getModels&make=porsche&year=2005";

var response = await client.GetAsync(apiUrl);

if (response.IsSuccessStatusCode)
{
    string jsonData = await response.Content.ReadAsStringAsync();
    
    jsonData = jsonData.Replace("?", "").Replace("(","");
    jsonData = jsonData.Replace(")", "").Replace(";", "");
    jsonData = jsonData.Trim();


    var data = JsonConvert.DeserializeObject<Car>(jsonData);

    Console.WriteLine($"Make: {data.Make}");
    Console.WriteLine($"Model: {data.Model}");
    Console.WriteLine($"Year: {data.Year}");
}
else
{
    Console.WriteLine($"Error : {response.StatusCode}");
}


public class Car
{
    public string Model { get; set; }
    public string Make { get; set; }
    public int Year { get; set; }
}