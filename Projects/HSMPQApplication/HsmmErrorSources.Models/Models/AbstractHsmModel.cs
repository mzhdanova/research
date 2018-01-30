using Newtonsoft.Json;

namespace HsmmErrorSources.Models.Models
{
    public abstract class AbstractHsmModel : IHsmModel
    {
        /// <summary>
        /// Transition Probability Markov Matrix (nxn)
        /// </summary>

        public double[,] A { get; set; }

        /// <summary>
        /// Symbol Probability Matrix (qxn)
        /// </summary>

        public double[,] B { get; set; }

        /// <summary>
        /// Initial state probability distribution(n)
        /// </summary>
        public double[] Pi { get; set; }

        /// <summary>
        /// Quasi-periods' lengths distribution (Dmax x n)
        /// </summary>
        public double[,] F { get; set; }

        /// <summary>
        /// Number of model states
        /// </summary>
        [JsonIgnore]
        public int N
        {
            get { return A.GetLength(0); }
        }
        /// <summary>
        /// Power of observations alphabeth
        /// </summary>
        [JsonIgnore]
        public int Q
        {
            get { return B.GetLength(0); }
        }
    }
}
