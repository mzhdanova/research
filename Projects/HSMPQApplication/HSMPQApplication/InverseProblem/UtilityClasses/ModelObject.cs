using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HMMQPN_Model;

namespace HSMPQApplication.InverseProblem
{
    class ModelObject
    {
        private string model_name = null;
        private HMM_QPN model = null;
        public string ModelName
        {
            get { return model_name; }
            set { model_name = value; }
        }
        public  HMM_QPN Model
        {
            get { return model; }
            set { this.model = value; }
        }
        public ModelObject(string modelName, HMM_QPN model)
        {
            this.model_name = modelName;
            this.model = model;
        }
    }
}
