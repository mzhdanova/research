using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HsmmErrorSources.Generation.Utils
{
    class MatrixUtils
    {
        public static double[] GetRow(double[,] a, int rowNumber) {
            int n = a.GetLength(1);
            double[] arr = new double[n];
            for (int j = 0; j < n; j++)
            {
                arr[j] = a[rowNumber, j];
            }
            return arr;
        }

        public static double[] GetColumn(double[,] a, int colNumber)
        {
            int n = a.GetLength(0);
            double[] arr = new double[n];
            for (int j = 0; j < n; j++)
            {
                arr[j] = a[j, colNumber];
            }
            return arr;
        }
    }
}
