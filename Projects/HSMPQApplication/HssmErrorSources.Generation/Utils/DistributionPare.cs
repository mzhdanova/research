using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HssmErrorSources.Generation.Utils
{
    /// <summary>
    /// A class representing a pare (value, probability)
    /// </summary>
    public class DistributionPare
    {
        private float probability;
        public float Probability {
            get { return probability; }
            set { probability = value; }
        }
        private int value;
        public int Value {
            get { return value; }
            set { this.value = value; }
        }
        public DistributionPare(int value, float probability)
        {
            this.value = value;
            this.probability = probability;
        }
        override public string ToString()
        {
            return "(" + this.value.ToString() + ";" + this.probability.ToString() + ")";
        }
    }
}
