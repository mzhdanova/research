using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using HSMPQApplication.InverseProblem;
using HMMQPN_Model;
namespace HSMPQApplication.ExperimentManager
{
    class CrossModelComputationPreparator
    {
        private string modelsFolderPath = null;
        private string sequencesFolderPath = null;
        public CrossModelComputationPreparator(string modelsFolderPath, string sequencesFolderPath)
        {
            this.modelsFolderPath = modelsFolderPath;
            this.sequencesFolderPath = sequencesFolderPath;
        }
        public List<ModelObject> getModelsList()
        {
            if (this.modelsFolderPath == null) return null;
            try
            {
                string[] files = Directory.GetFiles(this.modelsFolderPath);
                if (files == null && files.Length == 0) return null;
                List<ModelObject> result = new List<ModelObject>();
                for (int i = 0; i <= files.Length; i++)
                {
                    try
                    {
                        HMM_QPN Model = new HMM_QPN(files[i]);
                        if (Model.IsCorrect() == 1)
                        {
                            result.Add(new ModelObject(files[i], Model));
                        }
                    }
                    catch
                    {
                        //TODO do smth or change try to if
                    }
                }
                return result;
            }
            catch
            {
                return null;
            }
        }

        public List<SequenceObject> getSequencesList(int sequenceSize)
        {
            if (this.sequencesFolderPath == null) return null;
            try
            {
                string[] files = Directory.GetFiles(this.sequencesFolderPath);
                if (files == null && files.Length == 0) return null;
                List<SequenceObject> result = new List<SequenceObject>();
                for (int i = 0; i <= files.Length; i++)
                {
                    try
                    {//Может вылететь если последовательность в файле недостаточной длины
                        int[] seq = HMM_PSM.GetOutputSequence(files[i], sequenceSize);
                        result.Add(new SequenceObject(files[i], seq));
                    }
                    catch
                    {
                        //TODO do smth or change try to if
                    }
                }
                return result;
            }
            catch
            {
                return null;
            }
        }
    }
}
