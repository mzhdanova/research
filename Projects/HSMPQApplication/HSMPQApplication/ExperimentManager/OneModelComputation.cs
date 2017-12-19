using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HMMQPN_Model;
using HSMPQApplication.InverseProblem;

namespace HSMPQApplication.ExperimentManager
{
    class OneModelComputation
    {
        private int step = 0;
        private int maxSize = 0;
        private SequenceObject sequence;
        private ModelObject model;
        public OneModelComputation(ModelObject model, SequenceObject sequence, int step, int maxSize)
        {
            this.model = model;
            this.sequence = sequence;
            this.step = step;
            this.maxSize = maxSize;
        }

        public List<double> compute()
        {
            List<double> result = new List<double>(); 
            for (int i = step; i<=maxSize; i+=step)
            {
            Likelihood ls = new Likelihood(SequenceUtils<int>.getSubsequence(sequence.Sequence, 0, i), model.Model);
            double value = ls.FullProbability(i);
            result.Add(value);
            }
            return result;
        }

    }
}
