using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using HSMPQApplication.Model;

namespace HSMPQApplication.InverseProblem
{
    class LikelihoodFerguson
    {
        public int[] O;
        public FergusonModel Model;

        public double[, ,] alpha;
        private double[] P;

        public LikelihoodFerguson(int[] o, FergusonModel model)
        {
            O = o;
            Model = model;
            int D = model.MaxPeriodOverall();
            alpha = new double[model.n, D + 1, o.Length + Model.MaxPeriodOverall()];
            P = new double[o.Length + Model.MaxPeriodOverall()];
            for (int r = 0; r < o.Length + Model.MaxPeriodOverall(); r++)
            {
                for (int i = 0; i < model.n; i++)
                    for (int d = 0; d <= D; d++)
                        alpha[i, d, r] = -1;
                P[r] = -1;
            }
        }
        /// <summary>
        /// Вероятность наблюдать последовательность O_{1:T} при предположении, что 
        /// 1) Первое состояние началось в момент времени 1 или до этого
        /// 2) Последнее состояние закончилось в момент времени T или после него.
        /// </summary>
        /// <param name="t">T</param>
        /// <returns></returns>
        public double FullProbability(int t)
        {
            double sum = 0;
            int count=0;
            for (int j = 0; j < Model.n; j++)
                for (int d = 1; d <= Model.MaxPeriodOverall(); d++)
                {
                    if (Model.ProbabilityByValueAndState(d, j) != 0F)
                    {
                        for (int d1 = 1; d1 <= d; d1++)
                        {
                            double prod =(1D/d)* Probability(t - d1);
                            if (prod != 0F) prod *= Alpha(j, d, t - d1 + d);
                            if (prod != 0F)
                            {
                                //                      Debug.WriteLine("fullprod(" + j + ", " + d1 + ", " + t + "): ");
                                prod *= b(j, d, t - d1 + d);
                            }
                            Debug.WriteLine("prod(" + j + ", " + d + ", " + d1 + "): " + prod);
                            count++;
                            Debug.WriteLine("count= " + count);
                            sum += prod;
                            if (sum > 1)
                            {
                            }
                        }
                    }
                }
            return sum;
        }
        /// <summary>
        /// Вероятность наблюдать последовательность O_{1:T} при предположении, что 
        /// 1) Первое состояние началось в момент времени 1 или до этого
        /// 2) Последнее состояние закончилось в момент времени T
        /// </summary>
        /// <param name="t">T</param>
        /// <returns></returns>
        public double Probability(int t)
        {
            if (t <= 0) return 1;
            else if (P[t] != -1) return P[t];
            else
            {
                double sum = 0;
                for (int i = 0; i < Model.n; i++)
                    for (int d = 1; d <= Model.MaxPeriodOverall(); d++)
                    {
                        double prod = Probability(t - d);
                        // если первый множитель 0, то остальные можно не считать.
                        if (prod != 0F)
                            prod *= Alpha(i, d, t);
                        if (prod != 0F)
                        {
                        //    Debug.WriteLine("prob("+t+"): ");
                            prod *= b(i, d, t);
                        }
                        sum += prod;
                    }
                if (sum > 1)
                {
                }
                P[t] = sum;
                return sum;
            }
        }
        public double Alpha(int i, int d, int t)
        {
//            Debug.WriteLine("Alpha(" + i + ", " + d + ", " + t + ")");
            //для такого случая Pi должно быть предельными вероятностями матрицы переходов.
            if (t <= 0)
            {
                double alp = Model.Pi[i] * Model.ProbabilityByValueAndState(d, i);
//                Debug.WriteLine("Alpha(" + i + ", " + d + ", " + t + "): " +alp);
                return alp;
            }
            else if (alpha[i, d, t] != -1)
            {
//                Debug.WriteLine("Alpha(" + i + ", " + d + ", " + t + "): " + alpha[i, d, t]);
                return alpha[i, d, t];
            }
            else
            {
//                Debug.WriteLine("Calculation:");
                double sum = 0;
                for (int i1 = 0; i1 < Model.n; i1++)
                    for (int d1 = 1; d1 <= Model.MaxPeriodOverall(); d1++)
                    {
//                        Debug.WriteLine("new period:" + d1);
//                        Debug.WriteLine("A: " + Model.A[i1, i] + "; p(d):" + Model.ProbabilityByValueAndState(d, i));
                        double prod = Model.A[i1, i] * Model.ProbabilityByValueAndState(d, i);
//                        Debug.WriteLine("Production: " + prod);
                        if (prod != 0F)
                        {
//                            Debug.WriteLine("Alpha(" + i + ", " + d + ", " + t + ") calls calculation of Alpha(" + i1 + "," + d1 + "," + (t - d) + ")");
                            prod *= Alpha(i1, d1, t - d);
//                            Debug.WriteLine("Production: " + prod);
                        }
                        if (prod != 0F)
                        {
//                            Debug.WriteLine("Alpha(" + i + ", " + d + ", " + t + ") calls calculation of b(" + i1 + "," + d1 + "," + (t - d) + ")");
                    //        Debug.WriteLine("alpha(" + i + ", " + d + ", " + t + "): ");
                            prod *= b(i1, d1, t - d);

//                            Debug.WriteLine("Production: " + prod);
                        }
                        if (prod != 0F)
                        {
//                            Debug.WriteLine("Alpha(" + i + ", " + d + ", " + t + ") calls calculation of Probability(" + (t - d - d1) + ")");
                            prod *= Probability(t - d - d1);
 //                           Debug.WriteLine("Production: " + prod);
                        }
                        if (prod != 0F)
                        {
//                            Debug.WriteLine("Alpha(" + i + ", " + d + ", " + t + ") calls calculation of Probability(" + (t - d) + ")");
                            prod /= Probability(t - d);
//                            Debug.WriteLine("Devision: " + prod);
                        }
                        sum += prod;

                    }
                alpha[i, d, t] = sum;
//                Debug.WriteLine("Alpha(" + i + ", " + d + ", " + t + "): " + sum);
                return sum;

            }

        }
        //public float b(int i, int d, int t)
        //{
        //    if (t <= 0) return 1;
        //    else
        //    {
        //        float prod=1;
        //        float[] fi = HMM_QPN.integral(Model.Ro[i], Model.Ro[i].Length, d);
        //        //TODO: Хранить фи
        //        for (int theta = 1; theta <= d; theta++)
        //        {
        //            //считаем что в отриц части может быть что угодно, то есть любой символ с вероятностью 1.
        //            if (t - d + theta <= 0) prod *= 1;
        //            else
        //            //!!! вообще говоря плохая проверка. Нужно чтобы проверялась не длина последовательности, а длина для которой считается вероятность... придумать как задать
        //            if (t - d + theta > O.Length-1) prod *= 1;
        //            else
        //            {
        //                int I = MultiplicativeGroupIndicator(O[t - d + theta], Model.q);
        //                prod *= (I == 1) ? fi[theta - 1] * Model.Per[i] * d * Model.B[i, O[t - d + theta] - 1] : (1 - fi[theta - 1] * Model.Per[i] * d);
        //            }
        //        }
        //        return prod;
        //    }
        //}
        //public double b(int i, int d, int t)//t - правая граница
        //{
        //    if (t - d <= 0 && t <= 0 || t - d > O.Length) return 1;//или t > O.Length
        //    else
        //    {
        //        double prod = 1;
        //        double[] fi = HMM_QPN.integral(Model.Ro[i], Model.Ro[i].Length, d);
        //        //TODO: Хранить фи
        //        int m = 1;
        //        int k = d;
        //        if (t - d > 0)
        //        {
        //            m = 1;
        //            Debug.WriteLine("m: t - d > 0 " + m);
        //        }
        //        else
        //        {
        //            m = 1 - t + d;
        //            Debug.WriteLine("m: t - d <= 0 " + m);
        //        }
        //        if (t <= O.Length - 1)
        //        {
        //            k = d;
        //            Debug.WriteLine("k:t <= O.Length " + k);
        //        }
        //        else
        //        {
        //            k = O.Length - 1 - t + d;
        //            Debug.WriteLine("k: t > O.Length " + k);
        //        }
        //        Debug.WriteLine("from " + m + "; to " + k);

        //        for (int theta = m; theta <= k; theta++)
        //        {
        //            int I = MultiplicativeGroupIndicator(O[t - d + theta], Model.q);
        //            Debug.Write(" position: " + (t - d + theta) + " I(" + O[t - d + theta] + ", Model.q" + "): " + I);
        //            Debug.Write(" fi: " + fi[theta - 1]);
        //            double mult = (I == 1) ? fi[theta - 1] * Model.Per[i] * d * Model.B[i, O[t - d + theta] - 1] : (1 - fi[theta - 1] * Model.Per[i] * d);
        //            Debug.WriteLine(" mult(" + theta + "): " + mult);
        //            prod *= mult;
        //        }
        //        return prod;
        //    }
        //}
        public double b(int i, int d, int t)//t - правая граница
        {
      //      Debug.WriteLine("b(" + i + "," + d + "," + t + "): ");
            if (t - d <= 0 && t <= 0 || t - d >= O.Length)
            {
     //           Debug.WriteLine("b(" + i + "," + d + "," + t + "): " + 1);
                return 1;//или t > O.Length
            }
            else
            {
                double prod = 1;
                int m = 1;
                int k = d;
                if (t - d > 0)
                {
                    m = 1;
//                    Debug.WriteLine("m: t - d > 0 " + m);
                }
                else
                {
                    m = 1 - t + d;
//                    Debug.WriteLine("m: t - d <= 0 " + m);
                }
                if (t <= O.Length-1)
                {
                    k = d;
//                    Debug.WriteLine("k:t <= O.Length " + k);
                }
                else
                {
                    k = O.Length-1 - t + d;
//                    Debug.WriteLine("k: t > O.Length " + k);
                }
   //             Debug.WriteLine("from " + m + "; to " + k);
                for (int theta = m; theta <= k; theta++)
                {
   //                 Debug.Write(" position: " + (t - d + theta));
   //                 Debug.Write(" d: " + (double)d);

                    double mult = (double)Model.B[i, O[t - d + theta]] ;
   //                 Debug.WriteLine(" mult(" + theta + "): " + mult);
                    prod *= mult;
                }
    //            Debug.WriteLine("b(" + i + "," + d + "," + t + "): " + prod);
                return prod;
            }
        }
    }
}

