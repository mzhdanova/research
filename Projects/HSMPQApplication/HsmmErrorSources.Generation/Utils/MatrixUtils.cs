using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HsmmErrorSources.Generation.Utils
{
    class MatrixUtils
    {
        public static double[] GetRow(double[,] a, int rowNumber)
        {
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

        public static bool IsStochasticByRows(double[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (!DoubleUtils.AreEqual(GetRow(matrix, i).Sum(), 1))
                {
                    return false;
                }
            }
            return true;
        }

        public static bool IsStochasticByColumns(double[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                if (!DoubleUtils.AreEqual(GetColumn(matrix, i).Sum(), 1))
                {
                    return false;
                }
            }
            return true;
        }

        public static bool IsTwiceStochastic(double[,] matrix)
        {
            return IsStochasticByRows(matrix) && IsStochasticByColumns(matrix);
        }

        public static bool IsStochasticByRows(double[][] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (!(DoubleUtils.AreEqual(matrix[i].Sum(), 1)))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
