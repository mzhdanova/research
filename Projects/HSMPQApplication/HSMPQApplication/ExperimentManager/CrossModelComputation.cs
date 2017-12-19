using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HMMQPN_Model;
using HSMPQApplication.InverseProblem;
namespace HSMPQApplication.ExperimentManager
{
    class CrossModelComputation
    {
        private List<ModelObject> modelsList = null;
        private List<SequenceObject> sequencesList = null;
        private int segmentSize = 0;
        public CrossModelComputation(List<ModelObject> modelsList, List<SequenceObject> sequencesList, int segmentSize)
        {
            this.modelsList = modelsList;
            this.sequencesList = sequencesList;
            this.segmentSize = segmentSize;
        }
        public List<CrossModelComputationResultItem> compute()
        {
            List<CrossModelComputationResultItem> result = new List<CrossModelComputationResultItem>();
            if ((segmentSize <= 0) || (modelsList == null) || (modelsList.Count == 0) || (sequencesList == null) || (sequencesList.Count == 0)) return null;
            foreach (ModelObject model in modelsList)
                foreach (SequenceObject o in sequencesList)
                {
                    try
                    {
                        if (model.Model != null && o.Sequence != null)
                        {
                            LikelihoodSplit ls = new LikelihoodSplit(segmentSize);
                            double[] value = ls.calculateSplitedLikelihood(model.Model, o.Sequence);
                            result.Add(new CrossModelComputationResultItem(model.ModelName, o.SequenceName, averageProbability(value)));
                        }
                        else
                        result.Add(new CrossModelComputationResultItem(model.ModelName, o.SequenceName, -1));
                    }
                    catch
                    {
                        result.Add(new CrossModelComputationResultItem(model.ModelName, o.SequenceName, -1));
                    }

                }
            return result;
        }

        private double averageProbability(double[] probabilitiesArray)
        {
            if (probabilitiesArray == null || probabilitiesArray.Length == 0) return -1;
            double total = 0;
            for (int i = 0; i < probabilitiesArray.Length; i++)
            {
                total += probabilitiesArray[i];
            }
            return (total / probabilitiesArray.Length);
        }
        public static string[,] computationResultsAsMatrix(List<CrossModelComputationResultItem> list)
        {
            if (list == null) return null;
            List<string> modelNames = new List<string>();
            List<string> sequencesNames = new List<string>();
            foreach (CrossModelComputationResultItem l in list)
            {
                if (!modelNames.Contains(l.ModelName)) { modelNames.Add(l.ModelName); }
                if (!sequencesNames.Contains(l.SequenceName)) sequencesNames.Add(l.SequenceName);
            }
            //todo: поменять это как-то, чтобы не было двойного прохода
            string[,] result = new string[modelNames.Count+1, sequencesNames.Count+1];
            foreach (CrossModelComputationResultItem l in list)
            {
                int i = modelNames.IndexOf(l.ModelName)+1;
                int j = sequencesNames.IndexOf(l.SequenceName)+1;
                if (i>=0&&j>=0)
                {
                    result[0, j] = l.SequenceName;
                    result[i, 0] = l.ModelName;
                    result[i, j] = l.Value.ToString();
               }
            }
            return result;
        }
        /// <summary>
        /// Для набора вероятностей для разных моделей и последовательностей считает расстояния по критерию максимальной взаимной информации
        /// </summary>
        /// <param name="probabilities">Множество вероятностей для набора моделей и последовательностей </param>
        /// <returns></returns>
        public List<CrossModelComputationResultItem> computeMaximumMutialInformationDistances(List<CrossModelComputationResultItem> probabilities)
        {
            List<string> modelNames = new List<string>();
            List<string> sequencesNames = new List<string>();
            foreach (CrossModelComputationResultItem l in probabilities)
            {
                if (!modelNames.Contains(l.ModelName)) { modelNames.Add(l.ModelName); }
                if (!sequencesNames.Contains(l.SequenceName)) sequencesNames.Add(l.SequenceName);
            }
            //todo: поменять это как-то, чтобы не было двойного прохода
            double[,] probs = new double[modelNames.Count, sequencesNames.Count];
            foreach (CrossModelComputationResultItem l in probabilities)
            {
                int i = modelNames.IndexOf(l.ModelName);
                int j = sequencesNames.IndexOf(l.SequenceName);
                if (i >= 0 && j >= 0)
                {
                    probs[i, j] = l.Value;
                }
            }
            double[,] mmis= new double[probs.GetLength(0), probs.GetLength(1)];
            List<CrossModelComputationResultItem> result = new List<CrossModelComputationResultItem>();
            for (int i=0; i<probs.GetLength(0);i++)
            {
                            for (int j=0; j<probs.GetLength(1);j++)
                            {
                                double sum=0;
                                for (int k=0;k<probs.GetLength(0);k++)
                                {
                                    sum+=probs[k,j];
                                }
                                mmis[i,j] = Math.Log10(probs[i,j])-Math.Log10(sum);
                                result.Add(new CrossModelComputationResultItem(modelNames.ElementAt(i), sequencesNames.ElementAt(j), mmis[i, j]));
                            }
            }
            return result;
        }

    }
}
