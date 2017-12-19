using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HSMPQApplication.ExperimentManager
{
    class CrossModelComputationResultItem
    {
        private string model_name = null;
        private string sequence_name = null;
        private double value = 0;
        public string ModelName
        {
            get { return model_name; }
            set { model_name = value; }
        }
        public string SequenceName
        {
            get { return sequence_name; }
            set { sequence_name = value; }
        }
        public double Value
        {
            get { return value; }
            set { this.value = value; }
        }
        public CrossModelComputationResultItem(string modelName, string sequenceName, double value)
        {
            this.model_name = modelName;
            this.sequence_name = sequenceName;
            this.Value = value;
        }
    }
}
