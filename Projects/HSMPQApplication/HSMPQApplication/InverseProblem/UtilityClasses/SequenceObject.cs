using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HSMPQApplication.InverseProblem
{
    class SequenceObject
    {
        private string sequence_name = null;
        private int[] sequence = null;
        public string SequenceName
        {
            get { return sequence_name; }
            set { sequence_name = value; }
        }
        public int[] Sequence
        {
            get { return sequence; }
            set { this.sequence = value; }
        }
        public SequenceObject(string sequenceName, int[] sequence)
        {
            this.sequence_name = sequenceName;
            this.sequence = sequence;
        }
    }
}
