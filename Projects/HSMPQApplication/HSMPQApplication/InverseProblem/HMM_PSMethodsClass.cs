using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Input_lib;
using HMMQPN_Model;

namespace HSMPQApplication.InverseProblem
{
    class HMM_PSM
    {
        public static int[] GetOutputSequence(string filename, int length)
        //считывает из файла выходную последовательность
        {
            InStreamer streamer = new InStreamer(filename, length);
            return streamer.GetOutputSequence(length);
        }

        public static int[] GetOutputSequenceFromZero(string filename, int length)
        //считывает из файла выходную последовательность
        {
            InStreamer streamer = new InStreamer(filename, length);
            return streamer.GetOutputSequenceFromZero(length);
        }

        public static double AverageErrorProbability(int[] res)
        {
            int T = res.Length;
            if (res == null) return 0;
            if (T == 0) return 0;
            int errorcount=0;
            for (int i = 0; i < T; i++)
            {
                if (res[i] > 0) errorcount++;
            }
            return (double)errorcount / (double)T;
        }

#region Старая вероятность (по рабинеру)
        public static double SymbolFinalProbability(HMM_QPN Model, double fi, int d, int i, int symbol)
        {
            double smb_final_prob = 0;
            if (symbol == 0)
                smb_final_prob = 1 - fi * Model.Per[i] * d;
            else smb_final_prob = fi * Model.Per[i] * d * Model.B[i, symbol - 1];
            return smb_final_prob;
        }

        public static double Likelihood(HMM_QPN Model, int[] res, out double[,] norm_alpha_par, out double[,] alpha_par, out double[] norm_coeff, out double prob)// считает вероятность того, что последовательность наблюдений res получена с помощью модели Model
        //res numeruetsya ot 1
        {
            #region Описание переменных
            int n = Model.A.GetLength(0);//число состояний
            int T = res.Length - 1;//длина последовательности наблюдений
            double[,] alpha = new double[n, T + 1];//прямая переменная
            double[,] auxiliary_alpha = new double[n, T + 1];
            double[,] norm_alpha = new double[n, T + 1];//нормированная прямая переменная
            double[] c = new double[T + 1];//коэффициенты нормировки
            int max_period = 0;//максимальная длительность по всем состояниям (у Рабинера D)
            #endregion
            #region Определение максимальной длительности по всем состояниям
            int i = 0;
            for (i = 0; i < n; i++)//определяем max_period
            {
                double[] f_values = Model.ValueFromDistribution(Model.F[i]);
                int max_in_state = (int)HMM_QPN.MaxElementOfArray(f_values);
                if (max_in_state > max_period) max_period = max_in_state;
            }
            #endregion
            //преобразуем p_i(d) к виду ряда распределения где d принадлежит от 1 до D(то есть) max_period,а вероятность =0 если такой длины нет
            #region Матрица плотностей длительностей состояний
            float[,] length_density = new float[n, max_period + 1];//матрица плотностей длительности состояний. 
            //Второй индекс соответствует длине, значение - вероятности
            for (i = 0; i < n; i++)
            {
                for (int d = 1; d <= max_period; d++)
                    length_density[i, d] = 0;//занулили все элементы матрицы
                for (int j = 0; j < Model.F[i].Length; j++)
                    length_density[i, Model.F[i][j].value] = Model.F[i][j].probability;//изменили те элементы, для которых вероятность нулю не равна
            }
            #endregion
            #region Старый вариант формул
            //#region Для t=1
            ////для t=1
            //c[1] = 0;
            //for (i=0; i<n; i++)
            //{
            //    if (length_density[i, 1] > 0)
            //    {
            //        float[] fi = new float[1];
            //        fi = HMM_QPN.integral(Model.Ro[i], Model.Ro[i].Length, 1);
            //        alpha[i, 1] = SymbolFinalProbability(Model, fi[0], 1, i, res[1]) * Model.Pi[i] * length_density[i, 1];
            //        auxiliary_alpha[i, 1] = SymbolFinalProbability(Model, fi[0], 1, i, res[1]) * Model.Pi[i] * length_density[i, 1];
            //    }
            //    else
            //    {
            //        alpha[i, 1] = 0;
            //        auxiliary_alpha[i, 1] =0;
            //    }
            //    c[1] += auxiliary_alpha[i, 1];
            //}
            //c[1] =(c[1]!=0)?1 / c[1]:0;//вычислили нормировочный коэффициент
            //for (i = 0; i < n; i++)
            //{
            //    norm_alpha[i, 1] = auxiliary_alpha[i, 1] * c[1];
            //}
            //#endregion
            //#region Для 1<t<=D
            ////вторая строчка формулы
            //int t=2;
            //for (t = 2; (t <= max_period)&&(t<=T); t++)
            //{
            //    c[t] = 0;
            //    for (i = 0; i < n; i++)
            //    {
            //        //первое слагаемое формулы 2
            //        float term1 = 0;
            //        if (length_density[i, t] > 0)
            //        {
            //            float[] fi = new float[t];
            //            fi = HMM_QPN.integral(Model.Ro[i], Model.Ro[i].Length, t);
            //            float prod_tilda_b1 = 1;//переменная для произведения b c волной
            //            for (int s = 1; s <= t; s++)
            //            {
            //                prod_tilda_b1 *= SymbolFinalProbability(Model, fi[s - 1], t, i, res[s]);
            //            }
            //            term1 = Model.Pi[i] * length_density[i, t] * prod_tilda_b1;
            //        }
            //        float term2 = 0;
            //        float norm_term2 = 0;
            //        for (int d = 1; d <= t - 1; d++)
            //            for (int j = 0; j < n; j++)
            //            {
            //                float prod_tilda_b2 = 1;
            //                if (length_density[i, d] > 0)
            //                {
            //                    float[] fi2 = new float[d];
            //                    fi2 = HMM_QPN.integral(Model.Ro[i], Model.Ro[i].Length, d);

            //                    for (int s = t - d + 1; s <= t; s++)
            //                    {
            //                        prod_tilda_b2 *= SymbolFinalProbability(Model, fi2[s - t + d - 1],d, i, res[s]); 
            //                    }
            //                    term2 += alpha[j, t - d] * Model.A[j, i] * length_density[i, d] * prod_tilda_b2;
            //                    norm_term2 += norm_alpha[j, t - d] * Model.A[j, i] * length_density[i, d] * prod_tilda_b2;
            //                }
            //            }
            //        alpha[i, t] = term1 + term2;
            //        auxiliary_alpha[i, t] = term1 + norm_term2;
            //        c[t] += auxiliary_alpha[i, t];
            //    }
            //    c[t] = (c[t] != 0) ? 1 / c[t] : 0;
            //    for (i = 0; i < n; i++)
            //    {
            //        norm_alpha[i, t] = auxiliary_alpha[i, t] * c[t];
            //    }
            //}
            //#endregion
            //#region Для t>D
            ////третья строчка формулы
            //for (t = max_period + 1; t <= T; t++)
            //{
            //    c[t] = 0;
            //    for (i = 0; i < n; i++)
            //    {
            //        float term = 0;
            //        float norm_term = 0;
            //        for (int d = 1; d <= max_period; d++)
            //            for (int j = 0; j < n; j++)
            //            {
            //                if (length_density[i, d] > 0)
            //                {
            //                    float prod_tilda_b = 1;
            //                    float[] fi = new float[d];
            //                    fi = HMM_QPN.integral(Model.Ro[i], Model.Ro[i].Length, d);

            //                    for (int s = t - d + 1; s <= t; s++)
            //                    {
            //                        prod_tilda_b *= SymbolFinalProbability(Model, fi[s - t + d - 1], d, i, res[s]); 
            //                    }
            //                    term += alpha[j, t - d] * Model.A[j, i] * length_density[i, d] * prod_tilda_b;
            //                    norm_term += norm_alpha[j, t - d] * Model.A[j, i] * length_density[i, d] * prod_tilda_b;
            //                }
            //            }
            //        alpha[i, t] = term;
            //        auxiliary_alpha[i, t] = norm_term;
            //        c[t] += auxiliary_alpha[i, t];
            //    }
            //    c[t] = (c[t] != 0) ? 1 / c[t] : 0;
            //    for (i = 0; i < n; i++)
            //    {
            //        norm_alpha[i, t] = auxiliary_alpha[i, t] * c[t];
            //    }
            //}
            //  #endregion
            #endregion Старый вариант формул
            #region Для t=1
            //для t=1
            c[1] = 0;
            for (i = 0; i < n; i++)
            {
                if (length_density[i, 1] > 0)
                {
                    double[] fi = new double[1];
                    fi = HMM_QPN.integral(Model.Ro[i], Model.Ro[i].Length, 1);
                    alpha[i, 1] = SymbolFinalProbability(Model, fi[0], 1, i, res[1]) * Model.Pi[i] * length_density[i, 1];
                    auxiliary_alpha[i, 1] = SymbolFinalProbability(Model, fi[0], 1, i, res[1]) * Model.Pi[i] * length_density[i, 1];
                }
                else
                {
                    alpha[i, 1] = 0;
                    auxiliary_alpha[i, 1] = 0;
                }
                c[1] += auxiliary_alpha[i, 1];
            }
            c[1] = (c[1] != 0) ? 1 / c[1] : 0;//вычислили нормировочный коэффициент
            for (i = 0; i < n; i++)
            {
                norm_alpha[i, 1] = auxiliary_alpha[i, 1] * c[1];
            }
            #endregion

            #region Для t<T
            int t = 2;

            for (t = 2; t <= T; t++)
            {
                c[t] = 0;
                for (i = 0; i < n; i++)
                {
                    double term = 0;
                    double norm_term = 0;
                    int D = max_period >= t ? t : max_period;
                    for (int d = 1; d <= D; d++)
                        for (int j = 0; j < n; j++)
                        {
                            if (length_density[i, d] > 0)
                            {
                                double prod_tilda_b = 1;
                                double[] fi = new double[d];
                                fi = HMM_QPN.integral(Model.Ro[i], Model.Ro[i].Length, d);

                                for (int s = t - d + 1; s <= t; s++)
                                {
                                    prod_tilda_b *= SymbolFinalProbability(Model, fi[s - t + d - 1], d, i, res[s]);
                                }
                                term += alpha[j, t - d] * Model.A[j, i] * length_density[i, d] * prod_tilda_b;
                                norm_term += norm_alpha[j, t - d] * Model.A[j, i] * length_density[i, d] * prod_tilda_b;
                            }
                        }
                    alpha[i, t] = term;
                    auxiliary_alpha[i, t] = norm_term;
                    c[t] += auxiliary_alpha[i, t];
                }
                c[t] = (c[t] != 0) ? 1 / c[t] : 0;
                for (i = 0; i < n; i++)
                {
                    norm_alpha[i, t] = auxiliary_alpha[i, t] * c[t];
                }
            }
            #endregion Для t<T
            double probability = 0;
            prob = 0;
            double coeffsum = 0;
            for (i = 0; i < n; i++)
            {
                //          probability+=norm_alpha[i,T];
                prob += alpha[i, T];
            }
            for (t = 1; t <= T; t++)
                coeffsum += c[t];
            probability = 1 / coeffsum;
            alpha_par = alpha;
            norm_alpha_par = norm_alpha;
            norm_coeff = c;
            return probability;
        }
        #endregion Старая вероятность (по рабинеру)
#region Новая вероятность (по Ю)
        //Переменная для максимальной длительности квазипериодов по всем состояниям
        public static int D = -1;
        //массив для альфа
        public static double[, ,] alphav;
        //массив для вероятностей наблюдать последовательность при заданной модели
        public static double[] likelihood;


        /// <summary>
        /// Метод вычисляющий вероятность наблюдать последовательность O при заданной модели Model
        /// </summary>
        /// <param name="Model"></param>
        /// <param name="O"></param>
        /// <returns></returns>
        public static double LikelihoodExtended(HMM_QPN Model, int[] O)
        {
            //Первый запуск метода. Заполняем элементы массивов alphav и likelihood -1 
            //(поскольку это вероятности, значение -1 больше никак появиться не может,
            //то есть это признак незаполненности элемента)
            if (D == -1)
            {
                D = Max_Period(Model);
                int N = Model.n;//число состояний
                // O нумеруется начиная с первого элемента, а не с нулевого. как и длительности
                alphav = new double[N, D + 1, O.Length + 1];//1-i, 2-d, 3-t
                likelihood = new double[O.Length + 1];//1-i, 2-d, 3-t
                for (int r = 0; r <= O.Length; r++)
                {
                    for (int i = 0; i < N; i++)
                        for (int d = 0; d <= D; d++)
                            alphav[i, d, r] = -1;
                    likelihood[r] = -1;
                }
            }
            //если последовательность пустая, то вероятность 1. Это может быть в случае, если мы забрались в отрицательную область по t
            if (O==null||O.Length==0) 
                return 1;
            int t = O.Length;//число элементов последвательности
            double sum = 0;

                for (int i = 0; i <Model.n; i++)
                    for (int d = 1; d <= D; d++)
                    {
                        if (Model.ProbabilityByValueAndState(d, i) == 0)
                        {
                            alphav[i, d, t] = 0; continue;
                        }
                        //смотрим посчитана ли вероятность P[O_1:t-d|lambda]
                        double formerlikelihood; 
                        if (t - d>=0&&likelihood[t - d] != -1)
                        {//эта вероятность уже была посчитана раньше и записана в массив
                            formerlikelihood=likelihood[t - d];
                        }
                        else
                        {//еще не была посчитана и должны посчитать
                           formerlikelihood = LikelihoodExtended(Model, SubSequence(O, 0, t - d - 1));
                            //и записать в массив
                           if (t - d>=0) likelihood[t-d] = formerlikelihood;
                        }
                        //смотрим посчитана ли вероятность alfa_t(i,d)
                        double formeralpha;
                        if (t>=0&&alphav[i, d, t] != -1)
                        {//эта вероятность уже была посчитана раньше и записана в массив
                            formeralpha= alphav[i, d, t];
                        }
                        else
                        {//еще не была посчитана и должны посчитать
                           formeralpha= alpha(Model, O, d, i, t);
                           //и записать в массив
                           if (t>=0) alphav[i, d, t] = formeralpha;
                        }
                        sum += formerlikelihood * formeralpha * b(Model, SubSequence(O, t - d, t-1), i, t, d);
                    }

                likelihood[t] = sum;   
                return sum;

        }

        public static double LikelihoodExtended1(HMM_QPN Model, int[] O)
        {
            int T=O.Length;
            D = Max_Period(Model);
            int  N = Model.A.GetLength(0);//число состояний
            alphav = new double[N, D + 1, T + 1];//1-i, 2-d, 3-t
            likelihood = new double[T + 1];//1-i, 2-d, 3-t
            //чистим
            for (int t = 0; t <= T; t++)
            {
                for (int i = 0; i < N; i++)
                    for (int d = 0; d <= D; d++)
                        alphav[i, d, t] = -1;
                likelihood[t] = -1;
                }
            double L = LikelihoodExtended(Model, O);
            return L;
                //    for (int t = 1; t <= T; t++)
                //    {
                //for (int i = 0; i < N; i++)
                //    for (int d = 1; d <= D; d++)
                //    {


                //        alpha[i, d, t] = -1;
                //    }
                //    }
        }

        #region private
        private static int Max_Period(HMM_QPN Model)
        {
            int max_period = 0;//максимальная длительность по всем состояниям (у Рабинера D)
            int i = 0;
            for (i = 0; i <= Model.A.GetLength(0)-1; i++)//определяем max_period
            {
                double[] f_values = Model.ValueFromDistribution(Model.F[i]);
                int max_in_state = (int)HMM_QPN.MaxElementOfArray(f_values);
                if (max_in_state > max_period) max_period = max_in_state;
            }
            return max_period;
        }

        private static int[] SubSequence(int[] O, int startIndex, int endIndex)
        {
            //если начальный и конечный <=0, то ничего не выбирается
            //если начальный <0 а конечный >0, то выбирается часть начиная с 0-ого элемента
            //если конечный индекс ==0 и начальный >0 то эксепшн
            //если конечный индекс >0 и >O.Length то эксепшн
            if (endIndex <=0 &&startIndex<=0) return null;
            if (endIndex >= 0 && endIndex > O.Length)
                throw new Exception("endIndex > O.Length");
            if (startIndex > 0 && endIndex == 0) throw new Exception("startIndex > 0 && endIndex == 0");
            if (startIndex < 0 && endIndex > 0)
            {
                    int[] result = new int[endIndex + 1];
                    int ind = 0;
                    for (int i = 0; i <= endIndex; i++)
                    {
                        result[ind] = O[i];
                        ind++;
                    }
                    return result;
                }
            
            else
            {
                int[] result = new int[endIndex - startIndex + 1];
                int ind = 0;
                for (int i = startIndex; i <= endIndex; i++)
                {
                    try
                    {
                        result[ind] = O[i];
                    }
                    catch { 
                    
                    }
                    ind++;
                }
                return result;
            }
        }

        private static double alpha(HMM_QPN Model, int[] O, int d, int i, int t)
        {
            double d_prob = Model.ProbabilityByValueAndState(d, i);
            // по первой ветке
            if (t <= 0) return
                Model.Pi[i] *d_prob;//вероятность наблюдать длину d в состоянии i
            else //по второй ветке
            {
                // если вероятность длительности в состоянии нулевая, то и альфа будет нулевой
                if (d_prob == 0)
                {
                    alphav[i, d, t] = 0;
                    return 0;
                }
                else
                {
                    //если вероятность не нулевая, то считаем по формуле
                    double sum = 0;

                    //внешняя сумма по всем состояниям
                    for (int i_prime = 0; i_prime < Model.n; i_prime++)
                    {
                        //смотрим посчитана ли вероятность P[O_1:t-d|lambda], это общий множитель для всех слагаемых
                        double formerlikelihood1;
                        if (t - d >= 0 && likelihood[t - d] != -1)// вторая часть так как изначально все элементы массива =-1
                        {
                            formerlikelihood1 = likelihood[t - d];
                        }
                        else
                        {
                            formerlikelihood1 = LikelihoodExtended(Model, SubSequence(O, 0, t - d - 1));
                            if (t - d >= 0) likelihood[t - d] = formerlikelihood1;
                        }

                        //по всем длительностям
                        for (int d_prime = 1; d_prime <= D; d_prime++)
                        {
                            //смотрим посчитана ли вероятность P[O_1:t-d-d_prime|lambda]
                            double formerlikelihood2;
                            if (t - d - d_prime >= 0 && likelihood[t - d - d_prime] != -1)
                            {
                                formerlikelihood2 = likelihood[t - d - d_prime];
                            }
                            else
                            {
                                formerlikelihood2 = LikelihoodExtended(Model, SubSequence(O, 0, t - d - d_prime - 1));
                                if (t - d - d_prime >= 0) likelihood[t - d - d_prime] = formerlikelihood2;
                            }
                            //смотрим посчитана ли вероятность alfa_t-d(i_prime,d_prime)
                            double formeralpha;
                            if (t - d >= 0 && alphav[i_prime, d_prime, t - d] != -1)
                            {
                                formeralpha = alphav[i_prime, d_prime, t - d];
                            }
                            else
                            {
                                formeralpha = alpha(Model, O, d_prime, i_prime, t - d);
                                if (t - d >= 0) alphav[i_prime, d_prime, t - d] = formeralpha;
                            }
                            sum += d_prob * formeralpha *
                            (b(Model, SubSequence(O, t - d - d_prime, t - d - 1), i_prime, t - d, d_prime) *
                            Model.A[i_prime, i] * formerlikelihood2) / formerlikelihood1;
                        }
                    }
                    alphav[i, d, t] = sum;
                    return sum;
                }
            }
        }
        /// <summary>
        /// Функция вычисления вероятности наблюдения частичной последовательности O_{t-d+1:t} в состоянии i, где d = O.length
        /// </summary>
        /// <param name="O">частичная последовательность</param>
        /// <param name="i">состояние</param>
        /// <param name="t">момент времени соответствующий концу частичной последовательности внутри целой</param>
        /// <param name="d">длинна квазипериода</param>
        /// <returns></returns>
        private static double b(HMM_QPN Model, int[] O, int i, int t, int d)
        {
            if (t <= 0) return 1;
            else
            {
                double prod = 1;
                if (O == null||O.Length==0) return 1;
                else
                {
                    //int o = O.Length;
                    if (d == 0) return 1;
                    int q = Model.B.GetLength(1) + 1;//мощность поля Галуа

                    double[] fi = HMM_QPN.integral(Model.Ro[i], Model.Ro[i].Length, d);
                    int theta;
                    for (theta= 0 ; theta < O.Length; theta++)
                    {
                        try
                        {
                            int I = MultiplicativeGroupIndicator(O[theta], q);//-1 из-за того что в реализации массив нумеруется с 0

                            prod *= (I == 1) ? fi[d - O.Length + theta] * Model.Per[i] * d * Model.B[i, O[theta] - 1] : (1 - fi[theta] * Model.Per[i] * d);
                        }
                        catch
                        { }
                    };
                    return prod;
                }
            }
        }

        private static int MultiplicativeGroupIndicator(int Symbol, int GaluaFieldCardinality)
        {
            if (Symbol < GaluaFieldCardinality && Symbol != 0)
                return 1;
            else return 0;
        }
    }

        #endregion private
    #endregion Новая вероятность (по Ю)


}

