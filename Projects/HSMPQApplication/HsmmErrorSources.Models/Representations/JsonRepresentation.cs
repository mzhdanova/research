using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HsmmErrorSources.Models.Models;
using System.Runtime.Serialization.Json;
using System.IO;
using Newtonsoft.Json;

namespace HsmmErrorSources.Models.Representations
{
    public class JsonRepresentation<T> where T : IHsmModel
    {
        public string Serialize(T model)
        {
            return JsonConvert.SerializeObject(model);
        }

        public T Deserialize(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}