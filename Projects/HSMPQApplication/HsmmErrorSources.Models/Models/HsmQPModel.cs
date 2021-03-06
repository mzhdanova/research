﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace HsmmErrorSources.Models.Models
{
    public class HsmQpModel : AbstractHsmModel
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public override ModelType Type
        {
            get { return ModelType.HsmQpModel; }
        }
        /// <summary>
        /// Error probability distributions set on the model segments, one for each state
        /// Fisrt dimension corresponds to states number n, in different states model segments may have different length
        /// </summary>
        public double[][] Rho { get; set; }

        /// <summary>
        /// Vector of length n containing average error probabilities in states
        /// </summary>
        public double[] Per { get; set; }
    }
}