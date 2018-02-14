using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace HsmmErrorSources.Models.Models
{
    public class HsmFergusonModel : AbstractHsmModel
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public override ModelType Type
        {
            get { return ModelType.HsmFergusonModel; }
        }
    }
}