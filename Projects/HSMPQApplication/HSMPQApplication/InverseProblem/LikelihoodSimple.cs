using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HMMQPN_Model;
using System.Diagnostics;
namespace HSMPQApplication.InverseProblem
{
    class LikelihoodSimple
    {
        public int[] O;
        public HMM_QPN Model;

        private double[, ,] alpha;
        private double[] P;

        public string listing = "";

        public LikelihoodSimple(int[] o, HMM_QPN model)
        {
            O = o;
            Debug.WriteLine("O: ");
            for (int i = 0; i < O.Length; i++)
                Debug.Write(O[i] + " ");
            Debug.WriteLine("__");
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
        /// 1) Первое состояние началось в момент времени 1
        /// 2) Последнее состояние закончилось в момент времени T
        /// </summary>
        /// <param name="t">T</param>
        /// <returns></returns>
        public double Probability(int t)
        {
            int d = Model.MaxPeriodOverall();
            if (t <= 0)
            {
                return 1;
            }
            else
                if (P[t] != -1) return P[t];
                else
                {
                    double sum = 0;
                    for (int i = 0; i < Model.n; i++)
                    {
                        // System.Diagnostics.Debug.Write("+");
                        // for (int d = 1; d <= Model.MaxPeriodOverall(); d++)
                        //{
                        //Пусть у нас только одна длительность d=D
                        double prod = Probability(t - d);
                        // System.Diagnostics.Debug.Write("(P[O_{" + (t - d) + "}]="+prod+")");
                        // если первый множитель 0, то остальные можно не считать.
                        if (prod != 0F)
                        {
                            double alph = Alpha(i, d, t);
                            prod *= alph;
                            //  System.Diagnostics.Debug.Write("* (Alpha(" + i + ", " + d + ", "+t+")="+alph+")");
                        }
                        if (prod != 0F)
                        {
                            double br = b(i, d, t);

                            prod *= br;
                            //   System.Diagnostics.Debug.Write("* (b(" + i + ", " + d + ", "+t+")="+br+")");
                        }
                        sum += prod;

                        // }
                    }
                    if (t == 30)
                    {
                    }
                    P[t] = sum;
                    return sum;
                }
        }
        public double Alpha(int i, int d, int t)
        {
            Debug.WriteLine("Alpha(" + i + ", " + d + ", " + t + ")");
            if (t - d < 0)
            {
                Debug.WriteLine("Alpha(" + i + ", " + d + ", " + t + "): " + 0);
                return 0;
            }
            else
                if (t == d)
                {
                    if (alpha[i, d, t] != -1)
                    {
                        Debug.WriteLine("Alpha(" + i + ", " + d + ", " + t + "): " + alpha[i, d, t]);
                        return alpha[i, d, t];
                    }
                    Debug.WriteLine("Pi: " + Model.Pi[i] + "; p(d): " + Model.ProbabilityByValueAndState(d, i));
                    //см лист 11.03.14 №1
                    alpha[i, d, t] = Model.Pi[i] * Model.ProbabilityByValueAndState(d, i);
                    Debug.WriteLine("Alpha(" + i + ", " + d + ", " + t + "): " + alpha[i, d, t]);
                    return alpha[i, d, t];
                }
                else if (alpha[i, d, t] != -1)
                {   
                    Debug.WriteLine("Alpha(" + i + ", " + d + ", " + t + "): " + alpha[i, d, t]);
                    return alpha[i, d, t];
                }
                else
                {
                    Debug.WriteLine("Calculation:");
                    double sum = 0;
                    for (int i1 = 0; i1 < Model.n; i1++)
                    //    for (int d1 = 1; d1 <= Model.MaxPeriodOverall(); d1++)
                    {// Типа одна длина возможна
                        int d1 = Model.MaxPeriodOverall();
                        Debug.WriteLine("max period:" + d1);
                        Debug.WriteLine("A: " + Model.A[i1, i] + "; p(d):" + Model.ProbabilityByValueAndState(d, i));
                        double prod = Model.A[i1, i] * Model.ProbabilityByValueAndState(d, i);
                        Debug.WriteLine("Production: " + prod);
                        if (prod != 0F)
                        {
                            Debug.WriteLine("Alpha(" + i + ", " + d + ", " + t + ") calls calculation of Alpha(" + i1 + "," + d1 + "," + (t - d) + ")");
                            prod *= Alpha(i1, d1, t - d);
                            Debug.WriteLine("Production: " + prod);
                        }
                        // если первый множитель 0, то остальные можно не считать.
                        if (prod != 0F)
                        {
                            Debug.WriteLine("Alpha(" + i + ", " + d + ", " + t + ") calls calculation of b(" + i1 + "," + d1 + "," + (t - d) + ")");
                            prod *= b(i1, d1, t - d);
                            Debug.WriteLine("Production: " + prod);
                        }
                        if (prod != 0F)
                        {
                            Debug.WriteLine("Alpha(" + i + ", " + d + ", " + t + ") calls calculation of Probability(" + (t - d - d1) + ")");
                            prod *= Probability(t - d - d1);
                            Debug.WriteLine("Production: " + prod);
                        }
                        if (prod != 0F)
                        {
                            Debug.WriteLine("Alpha(" + i + ", " + d + ", " + t + ") calls calculation of Probability(" + (t - d) + ")");
                            prod /= Probability(t - d);
                            Debug.WriteLine("Devision: " + prod);
                        }
                        sum += prod;
                    }
                    alpha[i, d, t] = sum;
                    Debug.WriteLine("Alpha(" + i + ", " + d + ", " + t + "): "+sum);
                    return sum;

                }

        }
        public double b(int i, int d, int t)//t - правая граница
        {
            Debug.WriteLine("b(" + i + "," + d + "," + t + "): ");
            if (t - d <= 0 && t <= 0 || t - d > O.Length)
            {
                Debug.WriteLine("b(" + i + "," + d + "," + t + "): "+0);
                return 0;//или t > O.Length
            }
            else
            {
                double prod = 1;
                double[] fi = HMM_QPN.integral(Model.Ro[i], Model.Ro[i].Length, d);
                //TODO: Хранить фи
                int m = 1;
                int k = d;
                if (t - d > 0)
                {
                    m = 1;
                    Debug.WriteLine("m: t - d > 0 " + m);
                }
                else
                {
                    m = 1 - t + d;
                    Debug.WriteLine("m: t - d <= 0 " + m);
                }
                if (t <= O.Length)
                {
                    k = d;
                    Debug.WriteLine("k:t <= O.Length " + k);
                }
                else
                {
                    k = O.Length - t + d;
                    Debug.WriteLine("k: t > O.Length " + k);
                }
                Debug.WriteLine("from " + m + "; to " + k);
                for (int theta = m; theta <= k; theta++)
                {
                    int I = MultiplicativeGroupIndicator(O[t - d + theta], Model.q);
                    Debug.Write(" position: " + (t - d + theta) + " I(" + O[t - d + theta] + ", " + Model.q + "): " + I);
                    Debug.Write(" fi: " + fi[theta - 1]);
                    Debug.Write(" Per: " + (double)Model.Per[i]);
                    Debug.Write(" d: " + (double)d);

                    double mult = (I == 1) ? (double)fi[theta - 1] * (double)Model.Per[i] * (double)d * (double)Model.B[i, O[t - d + theta] - 1] : (1 - (double)fi[theta - 1] * (double)Model.Per[i] * d);
                    if (I == 1) Debug.Write(" B: " + (double)Model.B[i, O[t - d + theta] - 1]);
                    Debug.WriteLine(" mult(" + theta + "): " + mult);
                    prod *= mult;
                }
                Debug.WriteLine("b(" + i + "," + d + "," + t + "): " + prod);
                return prod;
            }
        }
        private static int MultiplicativeGroupIndicator(int Symbol, int GaluaFieldCardinality)
        {
            if (Symbol <= GaluaFieldCardinality && Symbol != 0)
                return 1;
            else return 0;
        }

    }
}
