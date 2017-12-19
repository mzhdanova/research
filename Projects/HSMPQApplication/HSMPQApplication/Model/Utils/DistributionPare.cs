using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utils
{
    public class DistributionPare//задает пару (значение,вероятность). Будет использоваться для задания распределения длин квазипериодов
    {
        public float probability;
        public int value;
        public DistributionPare(int value, float probability)
        {
            this.value = value;
            this.probability = probability;
        }
        public void SetValue(int value)
        {
            this.value = value;
        }
        public void SetProbability(float probability)
        {
            this.probability = probability;
        }
        override public string ToString()
        {
            return "(" + this.value.ToString() + ";" + this.probability.ToString() + ")";
        }
    }
}
