using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HsmmErrorSources.Generation.Models.Qp
{
    class QpUtils
    {
        /// <summary>
        /// Calculates vector of probabilites of error locations based on scaling algorithm for QP-models
        /// </summary>
        /// <param name="rho">reference error location probabilities vector</param>
        /// <param name="t">length of the segment rho is to be scaled to</param>
        /// <returns>vector of error locationsprobabilities</returns>
        public static double[] CalculateErrorLocationDistribution(double[] rho, int t)
        {
            int l = rho.Length;
            double[] phi = new double[t];
            double nm = Convert.ToDouble(l) / t;//длина растяжения старого единичного отрезка в единицах нового

            if (nm <= 1)//старый единичный больше, чем новый единичный, тогда в новом отрезке больше точек, чем в старом
            {
                double d = 1 / nm;
                for (int i = 0; i < t; i++)
                {
                    if (i + 1 <= d)
                    {
                        phi[i] = PhiPc(rho, t, i + 1);
                    }
                    else
                    {
                        phi[i] = (d - i) * PhiPc(rho, t, d) + (i + 1 - d) * PhiPc(rho, t, i + 1);
                        d += 1 / nm;
                    }
                }
            }
            else //если новый единичный больше старого единичного, тогда точек в старом больше 
            {
                double delta_j = 1 / nm;
                double k = delta_j;
                double j;
                for (int i = 0; i <= t - 1; i++)
                {
                    for (j = k; (j < i + 1) && (j <= l * delta_j); j += delta_j)
                    {
                        phi[i] += PhiPc(rho, t, j) * delta_j;
                    }
                    if (j >= i + 1)
                    {
                        k = j;
                        phi[i] += PhiPc(rho, t, i + 1) * (i + 1 - k + delta_j);
                        if (j.CompareTo(l * delta_j) == -1)
                            phi[i + 1] = PhiPc(rho, t, k) * (k - i - 1);
                    }

                    else break;
                    k += delta_j;
                }
            }
            return phi;
        }
        /// <summary>
        /// Calculates value of the piecewise function Phi_PC in point j 
        /// </summary>
        /// <param name="Rho">error location probabilities distributions on the reference segment</param>
        /// <param name="t">length of the segment Rho is scaled to</param>
        /// <param name="j">point inside the new segment</param>
        /// <returns>value of the piecewise function Phi_PC in point j</returns>
        private static double PhiPc(double[] rho, int t, double j)
        {
            int i = 0;
            double s = -1;
            int l = rho.Length; //reference vector length
            double nm = Convert.ToDouble(t) / l;
            double mn = 1.0 / nm;
            while (i < l)
            {
                if (((nm * i).CompareTo(j) <= 0)
                    && (j.CompareTo(nm * (i + 1)) <= 0))
                {
                    s = (mn) * rho[i];
                    break;
                }
                else i++;
            }
            return s;
        }

    }
}
