using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using System.Security.Cryptography;
using Input_lib;
using System.IO;

namespace HSMPQApplication.Model
{
    class FergusonModel
    {
        public double[,] A; //Transition Probability Markov Matrix (nxn)
        public double[,] B; //Symbol Probability Matrix (qxn)
        public double[] Pi;//Initial state probability distribution(n)
        public DistributionPare[][] F;//ряд распределения длин квазипериодов(тут дожна быть матрица составленная из векторов пар {длина, вероятность})

        public int n //число состояний
        {
            get { return A.GetLength(0); }
        }
        public int q //число состояний
        {
            get { return B.GetLength(0); }
        }

        static RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
        static RC4_PRNG.RC4_PRNG rc4_prng = new RC4_PRNG.RC4_PRNG();

        public static double rc4_Rnd()
        {
            var bytes = new Byte[8];
            for (int i = 0; i < bytes.Length; i++)
                bytes[i] = rc4_prng.randomu8();
            // Step 2: bit-shift 11 and 53 based on double's mantissa bits
            var ul = BitConverter.ToUInt64(bytes, 0) / (1 << 11);
            Double d = ul / (Double)(1UL << 53);
            return d;
        }

        public static double Rnd()
        {
            var bytes = new Byte[8];
            rng.GetBytes(bytes);
            var ul1 = BitConverter.ToUInt64(bytes, 0) / (1 << 11);
            Double d1 = ul1 / (Double)(1UL << 53);
            ////var ul = BitConverter.ToUInt64(bytes, 0) / (1 << 11);
            //Double d = BitConverter.ToUInt64(bytes, 0) / (Double)(1UL << 64);
            return d1;
        }
        private static Random r = new Random(Convert.ToInt32(DateTime.Now.Millisecond));


        //Получение модели из файлf определенной структуры
        public FergusonModel(string filename)
        {
            InStreamer f = new InStreamer(filename);
            A = f.GetMatrix("matrix_tp");
            B = f.GetMatrix("matrix_sp");
            Pi = f.GetNumberVector("vector_Pi");
            F = f.GetDistribution("vector_f");
        }
        //Создание пустой модели
        public FergusonModel(int statenum, int outputnum)
        {
            A = new double[statenum, statenum];
            B = new double[outputnum, statenum];
            Pi = new double[statenum];
            F = new DistributionPare[statenum][];
        }

        #region DistributionPare
        public double[] ProbabilityFromDistribution(DistributionPare[] DP)
        {
            int n = DP.Length;
            double[] res = new double[n];
            for (int i = 0; i < n; i++)
                res[i] = DP[i].probability;
            return res;
        }
        public double[] ValueFromDistribution(DistributionPare[] DP)
        {
            int n = DP.Length;
            double[] res = new double[n];
            for (int i = 0; i < n; i++)
                res[i] = DP[i].value;
            return res;
        }

        #endregion DistributionPare


        public void StartGenerator(int count, Mode mode, PRNGMode rngMode) //будет вызываться от созданного экземпляра и запускать процесс генерации последовательности наблюдений
        {
            int n = A.GetLength(0);
            int state_number = ProbabilityMethod(Pi, rngMode);
            double[] Farr = ProbabilityFromDistribution(F[state_number]);
            int period_length = F[state_number][ProbabilityMethod(Farr, rngMode)].value;

            int stop = (count - period_length >= 0) ? period_length : count;
            if (File.Exists("res.txt")) File.Delete("res.txt");
            if (mode == HSMPQApplication.Mode.Test)
            {
                if (File.Exists("sost.txt")) File.Delete("sost.txt");
                if (File.Exists("sostdur.txt")) File.Delete("sostdur.txt");//тут будут пары (состояние длительность)
            }
            PQN_Method(state_number, period_length, stop, mode, rngMode);
            OutStreamer OutStream = new OutStreamer("sostdur.txt");
            OutStream.StringToFile(state_number + ";" + period_length);
            for (int counter = period_length; counter < count; counter++)// counter = period_length
            {
                double[] StolbecP = new double[n];
                StolbecP = MatrToArr(A, state_number);
                state_number = ProbabilityMethod(StolbecP, rngMode);

                Farr = ProbabilityFromDistribution(F[state_number]);
                period_length = F[state_number][ProbabilityMethod(Farr, rngMode)].value;
                stop = (count - period_length - counter >= 0) ? period_length : count - counter;
                OutStream = new OutStreamer("sostdur.txt");
                OutStream.StringToFile(state_number + ";" + period_length);
                PQN_Method(state_number, period_length, stop, mode, rngMode);
                counter += period_length - 1;
            }
        }

        #region Корректность параметров модели
        public int IsCorrect()
        //Коды ошибки:
        //0 - "Размерности вводимых параметров не соответствуют"
        //1 - корректно заданные параметры
        //2 - "Не все параметры заданы"
        //3 - "Для параметров не выполняются необходимые условия стохастичности"
        //4 - "Для параметров не выполняются необходимые условия адаптированности"
        {
            float eps = (float)0.00001;
            int res = 0;
            if ((A != null) && (B != null) && (Pi != null) && (F != null))
            {
                int state_qty = A.GetLength(0);//число состояний
                if (state_qty == Pi.Length &&
                    state_qty == A.GetLength(1) &&
                    (state_qty == B.GetLength(0)) &&//число строк в матрице В соответствует числу состояний
                    (state_qty == F.Length))
                {
                    //тут будет процедура проверяющая, является ли B.GetLength(1) степенью простого числа

                    #region Проверка стохастичности
                    //Матрицы A и B  должны удовлетворять условию стохастичности
                    //Условие стохастичности матрицы: сумма элементов в каждом из столбцов должна быть равна 1
                    //Сумма вероятностей длительностей в каждом состоянии должна быть равна 1
                    //Сумма всех Pi должна быть равна 1
                    int isstochastic = 1;
                    double sumA = 0;
                    double sumB = 0;
                    double sumPi = 0;
                    double sumF = 0;
                    for (int i = 0; i < state_qty; i++)
                    {
                        for (int j = 0; j < A.GetLength(1); j++)
                            sumA += A[i, j];
                        for (int j = 0; j < B.GetLength(1); j++)
                            sumB += B[i, j];

                        sumPi += Pi[i];

                        for (int j = 0; j < F[i].Length; j++)
                        {
                            sumF += F[i][j].probability;
                        }
                        if ((Math.Abs(sumA - 1) < eps) && (Math.Abs(sumB - 1) < eps) && (Math.Abs(sumF - 1) < eps)) isstochastic = 1; else { isstochastic = 0; break; }
                        sumA = 0;
                        sumB = 0;
                        sumF = 0;
                    }

                    if (isstochastic == 1 && sumPi == 1) isstochastic = 1; else isstochastic = 0;

                    #endregion Проверка стохастичности
                    if ((isstochastic == 1))
                        res = 1;
                    else res = 0;
                    return res;
                }
                return res;
            }

            return 2;
        }

        #endregion Корректность параметров модели

        public static double MinElementOfArray(double[] p)
        {
            double mini;
            int i = 0;
            int n = p.GetLength(0);
            while ((i < n) && (p[i] == 0)) i++;
            mini = p[i];
            for (i = 0; i < n; i++)
                if ((p[i] < mini) & (p[i] != 0)) mini = p[i];
            return mini;
        }
        public static double MaxElementOfArray(double[] p)
        {
            double maxi;
            int i = 0;
            int n = p.GetLength(0);
            while ((i < n) && (p[i] == 0)) i++;
            maxi = p[i];
            for (i = 0; i < n; i++)
                if ((p[i] > maxi) & (p[i] != 0)) maxi = p[i];
            return maxi;
        }
        public static int ProbabilityMethod(double[] a, HSMPQApplication.PRNGMode RngMode)
        /*Реализует вероятностный выбор. Наудачу кидается число и по нему выбирается 
         * нужное состояние.
         * Будет использоваться дважды - при выборе состояния канала(параметром
         * будет вектор финальных вероятностей) и при выборе нужного символа
         * (параметром будет вектор полученный с использованием матрицы условных
         * вероятностей и означающий полную верояность появления того или иного символа */
        {
            if (a == null || a.Length == 0) return 0;//подумать!!!
            int i;
            int s = 1;
            int n = a.Length;
            double[] aux = new double[n];
            for (i = 0; i < n; i++)
            {
                aux[i] = a[i];
            }
            //while (MinElementOfArray(aux) < 10)
            //{
            //    for (i = 0; i < n; i++)
            //        aux[i] = aux[i] * 10;
            //    s = s * 10;
            //}
            for (i = 1; i < n - 1; i++)
                aux[i] = aux[i - 1] + aux[i];
            aux[n - 1] = s;
            double x;
            switch (RngMode)
            {
                case HSMPQApplication.PRNGMode.Random:
                    x = (double)r.NextDouble(); break;
                case HSMPQApplication.PRNGMode.RNGCryptoServiceProvider:
                    x = (double)Rnd(); break;
                case HSMPQApplication.PRNGMode.RC4:
                    x = (double)rc4_Rnd(); break;
                default: x = 0; break;
            }            /*           Console.WriteLine("xxx");
                       Console.WriteLine(x.ToString());*/
            int index = -1;
            if ((x >= 0) && (x < aux[0])) index = 0;
            else
            {
                for (i = 1; i < n; i++)
                    if ((x >= aux[i - 1]) && (x < aux[i])) index = i;
            };
            if (x == aux[n - 1]) index = n - 1;
            /*           Console.WriteLine("prob result");
                       Console.WriteLine(index.ToString());*/
            return (index);
        }
        public static int BinaryProbabilityMethod(double p, HSMPQApplication.PRNGMode RngMode)
        /*Реализует вероятностный выбор. Наудачу кидается число и по нему выбирается 
         * нужное состояние.*/
        {
            if (p == 0D) return 0;
            int s = 1;
            double x;
            double aux = p;
            //while (aux < 10)
            //{
            //    aux = aux * 10;
            //    s = s * 10;
            //}
            switch (RngMode)
            {
                case HSMPQApplication.PRNGMode.Random:
                    x = (float)r.NextDouble(); break;
                case HSMPQApplication.PRNGMode.RNGCryptoServiceProvider:
                    x = (float)Rnd(); break;
                case HSMPQApplication.PRNGMode.RC4:
                    x = (float)rc4_Rnd(); break;
                default: x = 0; break;
            }
            if (x < aux) return 1; else return 0;
        }

        public void PQN_Method(int state_nubmer, int period_length, int stop, Mode mode, PRNGMode rndMode)
        {
            double[] p = new double[period_length];//вероятность ошибки в момент j

            int k = 0;
            double[] PSmb = MatrToArr(B, state_nubmer);//должен вернуть массив из элементов строки с номером state_nubmer матрицы B
            while (k < stop)
            {
                int Prob;
                Prob = ProbabilityMethod(PSmb, rndMode); 

                OutStreamer OutStream = new OutStreamer("res.txt");
                OutStream.SymbolToFile(Prob);
                if (mode == HSMPQApplication.Mode.Test)
                {
                    OutStreamer SostStream = new OutStreamer("sost.txt");
                    SostStream.SymbolToFile(state_nubmer);
                }

                k++;
            }
        }


        static double[] MatrToArr(double[,] P, int k)//возвращает в виде массива элементы К-той строки матрицы
        {
            int j;
            int n = P.GetLength(1);
            double[] Arr = new double[n];
            for (j = 0; j < n; j++)
            {
                Arr[j] = P[k, j];
            }
            return Arr;
        }

        public double ProbabilityByValueAndState(double Value, int State)
        {
            int n = this.F[State].Length;
            double res = 0;
            for (int i = 0; i < n; i++)
                if (this.F[State][i].value == Value) res = this.F[State][i].probability;
            return res;
        }

        public string FloatToString(double f)
        {
            return f.ToString().Replace(".", ",");
        }

        public override string ToString()
        {
            string str = "[vector_Pi]\r\n";
            for (int i = 0; i < n; i++)
                str += FloatToString(Pi[i]) + "\r\n";
            str += "#Markov transition probability matrix\r\n[matrix_tp]\r\n";
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                    str += FloatToString(A[i, j]) + " ";
                str += "\r\n";
            }
            str += "# Matrix of Symbol Probabilities (number of rows =  number of states; number of columns =field power)\r\n[matrix_sp]\r\n";
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < q; j++)
                    str += FloatToString(B[i, j]) + " ";
                str += "\r\n";
            }
            str += "[vector_f] #(first row = lengths, second = probabilites)\r\n";
            for (int i = 0; i < n; i++)
            {
                str += "\r\n";
                for (int j = 0; j < F[i].Length; j++)
                {
                    str += F[i][j].value + " ";
                }
                str += "\r\n";
                for (int j = 0; j < F[i].Length; j++)
                {
                    str += FloatToString(F[i][j].probability) + " ";
                }
                str += "\r\n";
            }
            str += "[End]";
            return str;
        }
        public double[][][] InitVarPhi()
        {
            double[][][] res = new double[n][][];
            for (int i = 0; i < n; i++)
            {
                res[i] = new double[MaxPeriodInState(i)][];
            }
            return res;
        }
        public int GetPeriodsNumberByState(int StateNumber)
        {
            return F[StateNumber].Length;
        }
        public int MaxPeriodInState(int stateNum)
        {
            double[] f_values = ValueFromDistribution(F[stateNum]);
            int max_in_state = (int)MaxElementOfArray(f_values);
            return max_in_state;

        }
        public int MaxPeriodOverall()
        {
            int max_period = 0;//максимальная длительность по всем состояниям (у Рабинера D)
            int i = 0;
            for (i = 0; i < this.n; i++)//определяем max_period
            {
                int max_in_state =MaxPeriodInState(i);
                if (max_in_state > max_period) max_period = max_in_state;
            }
            return max_period;
        }
    }

}


