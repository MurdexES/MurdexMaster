using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serl
{
    public interface ISerialiazation
    {

    }

    public class Serializator
    {
        public JsonSerializerSettings Settings = new()
        {
            TypeNameHandling = TypeNameHandling.All
        };

        public string Serialize<T>(T obj) where T : ISerialiazation
        {
            return JsonConvert.SerializeObject(obj, Settings);
        }

        public ISerialiazation Deserialiaze<T>(string json) where T : ISerialiazation
        {
            var result = JsonConvert.DeserializeObject<T>(json, Settings);
            return result;
        }
    }
}
