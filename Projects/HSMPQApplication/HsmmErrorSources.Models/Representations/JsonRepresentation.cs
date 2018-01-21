using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HsmmErrorSources.Models.Models;
using System.Runtime.Serialization.Json;
using System.IO;

namespace HsmmErrorSources.Models.Representations
{
    public class JsonRepresentation<T> where T : IHsmModel
    {
        private readonly DataContractJsonSerializer _serializer = new DataContractJsonSerializer(typeof(T));

        public string Serialize(T model)
        {
            MemoryStream ms = new MemoryStream();
            _serializer.WriteObject(ms, model);
            byte[] json = ms.ToArray();
            ms.Close();
            return Encoding.UTF8.GetString(json, 0, json.Length);
        }

        public T Deserialize(string json)
        {
            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(json));
            T deserializedModel = (T)_serializer.ReadObject(ms);
            ms.Close();
            return deserializedModel;

        }
    }
}
