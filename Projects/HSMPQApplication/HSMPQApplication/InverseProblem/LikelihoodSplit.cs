using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HMMQPN_Model;

namespace HSMPQApplication.InverseProblem
{
    class LikelihoodSplit
    {
        private int segment_size = 0;
        public int segmentSize 
        {
            get { return segment_size; }
            set
            {
                segment_size = value;  }
        }

        public LikelihoodSplit(int segmentSize)
        {
            segment_size = segmentSize;
        }

        public double[] calculateSplitedLikelihood(HMM_QPN model, int[] O)
        {
            if (segment_size <= 0) return null;
            else
            {
                int h = O.Length / segment_size;
                double[] result = new double[h];
                for (int i = 0; i < h ; i ++)
                {
                    int[] subseq = new int[segment_size+1];
                    for (int j = 1; j <= segment_size; j++)
                    {
                        subseq[j] = O[i*segment_size + j];
                    }
                    Likelihood lk = new Likelihood(subseq, model);
                    result[i] = lk.FullProbability(subseq.Length - 1);
                }
                return result;
            }
        }
    }
}
