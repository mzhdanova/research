using HsmmErrorSources.Models.Models;
using System.IO;
using Newtonsoft.Json;

namespace HsmmErrorSources.Models.Representations
{
    public class JsonRepresentation<T> where T : IHsmModel
    {
        public string Serialize(T model)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
            };
            return JsonConvert.SerializeObject(model, typeof(T), settings);
        }

        public T Deserialize(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }

        public void SerializeToFile(StreamWriter file, T model)
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Serialize(file, model);
        }

        public T DeserializeFromFile(StreamReader file)
        {
            JsonSerializer serializer = new JsonSerializer();
            return (T) serializer.Deserialize(file, typeof(T));
        }
    }
}