using HssmErrorSources.Generation.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HssmErrorSources.Generation.Models
{
    class HiddenSemiMarkovFergusonModel : IHiddenSemiMarkovModel
    {
        private double[,] a;
        /// <summary>
        /// Transition Probability Markov Matrix (nxn)
        /// </summary>
        public double[,] A
        {
            get { return a; }
            set
            {
                a = value;
            }
        }
        private double[,] b;
        /// <summary>
        /// Symbol Probability Matrix (qxn)
        /// </summary>
        public double[,] B
        {
            get { return b; }
            set
            {
                b = value;
            }
        }

        private double[] pi;
        /// <summary>
        /// Initial state probability distribution(n)
        /// </summary>
        public double[] Pi
        {
            get { return pi; }
            set
            {
                pi = value;
            }
        }

        private double [,] f;
        /// <summary>
        /// Quasi-periods' lengths distribution (Dmax x n)
        /// </summary>
        public double[,] F
        {
            get { return f; }
            set
            {
                f = value;
            }
        }
        /// <summary>
        /// Number of model states
        /// </summary>
        public int N
        {
            get { return a.GetLength(0); }
        }
        /// <summary>
        /// Power of observations alphabeth
        /// </summary>
        public int Q
        {
            get { return b.GetLength(0); }
        }

    }
}
