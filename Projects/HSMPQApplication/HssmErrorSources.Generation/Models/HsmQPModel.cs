using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HsmmErrorSources.Generation.Models
{
    public class HsmQPModel : AbstractHsmModel
    {
        private double[][] rho;
        /// <summary>
        /// Error probability distributions set on the model segments, one for each state
        /// Fisrt dimension corresponds to states number n, in different states model segments may have different length
        /// </summary>
        public double[][] Rho
        {
            get { return rho; }
            set { rho = value; }
        }

        private double[] per;
        /// <summary>
        /// Vector of length n containing average error probabilities in states
        /// </summary>
        public double[] Per
        {
            get { return per; }
            set { per = value; }
        }
    }
}
