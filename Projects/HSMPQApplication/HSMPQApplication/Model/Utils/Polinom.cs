using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HSMPQApplication.Model.Utils
{
    class Polinom
    {
        private int[,] coefficients;
        private int power;
        public Polinom(int power, int[,] coefficients)
        {
            this.coefficients = coefficients;
            this.power = power;
        }
/*        public int calculatePolinomValue(int x, int y)
        {
            int result = 0;
            for (int i = 0; i < power; i++)
                for (int j = 0; i < power;j++)
                {
                    result += coefficients[i, j] * x * y;//тут должна быть арифметика над полем галуа, наверное
                }
        }*/
    }
}
