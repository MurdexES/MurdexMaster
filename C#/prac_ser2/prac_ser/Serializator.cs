using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Serl
{
    public interface ISerialization
    {

    }

    public class Serializator
    {
        public JsonSerializerSettings settings = new()
        {
            TypeNameHandling = TypeNameHandling.All
        };

        public string Serialize<T>(T obj) where T : ISerialization
        {
            return JsonConvert.SerializeObject(obj, settings);
        }

        public ISerialization Deserialize<T>(string json) where T : ISerialization
        {
            var result = JsonConvert.DeserializeObject<ISerialization>(json, settings);
            return result;
        }
    }
}
