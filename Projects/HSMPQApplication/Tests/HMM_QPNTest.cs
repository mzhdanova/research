using HMMQPN_Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Utils;

namespace Tests
{
    
    
    /// <summary>
    ///Это класс теста для HMM_QPNTest, в котором должны
    ///находиться все модульные тесты HMM_QPNTest
    ///</summary>
    [TestClass()]
    public class HMM_QPNTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Получает или устанавливает контекст теста, в котором предоставляются
        ///сведения о текущем тестовом запуске и обеспечивается его функциональность.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Дополнительные атрибуты теста
        // 
        //При написании тестов можно использовать следующие дополнительные атрибуты:
        //
        //ClassInitialize используется для выполнения кода до запуска первого теста в классе
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //ClassCleanup используется для выполнения кода после завершения работы всех тестов в классе
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //TestInitialize используется для выполнения кода перед запуском каждого теста
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //TestCleanup используется для выполнения кода после завершения каждого теста
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        ///// <summary>
        /////Тест для ProbabilityMethod
        /////</summary>
        //[TestMethod()]
        //public void ProbabilityMethodTest()
        //{
        //    float[] a = {0.7F,0.2F,0.1F}; // TODO: инициализация подходящего значения
        //    int n=1000000;
        //    float f0=0;
        //    float f1=0;
        //    float f2=0;
        //    int cur;
        //    for (int i = 0; i < n; i++ )
        //    {
        //        cur = HMM_QPN.ProbabilityMethod(a);
        //        if (cur == 0) f0++;
        //        if (cur == 1) f1++;
        //        if (cur == 2) f2++;
        //    }
        //    f0 = f0 / n;
        //    f1 = f1 / n;
        //    f2 = f2 / n;

        //}

        ///// <summary>
        /////Тест для StartGenerator
        /////</summary>
        //[TestMethod()]
        //public void StartGeneratorTest()
        //{
        //    string filename = string.Empty; // TODO: инициализация подходящего значения
        //    HMM_QPN target = new HMM_QPN(filename); // TODO: инициализация подходящего значения
        //    int count = 1; // TODO: инициализация подходящего значения
        //    target.StartGenerator(count);
        //    Assert.Inconclusive("Невозможно проверить метод, не возвращающий значение.");
        //}

        /// <summary>
        ///Тест для integral
        ///</summary>
        [TestMethod()]
        public void integralTest()
        {
            double[] Ro = { 0.3F, 0.3F, 0.4F }; // TODO: инициализация подходящего значения
            int L = 3; // TODO: инициализация подходящего значения
            int T = 5; // TODO: инициализация подходящего значения

            double expected = 0F; // TODO: инициализация подходящего значения
            double[] actual;
            actual= HMM_QPN_Accessor.integral(Ro, L, T);
            for (int j = 0; j < T; j++)
            {

                if (j == 0)
                    expected = 0.18F;
                if (j == 1)
                    expected = 0.18F;
                if (j == 2)
                    expected = 0.18F;
                if (j == 3)
                    expected = 0.22F;
                if (j == 4)
                    expected = 0.24F;

                float epsilon = 0.0001F;
                bool correct = Math.Abs(actual[j] - expected) <= epsilon;
                Assert.AreEqual(correct, true);
            }


            L = 3; // TODO: инициализация подходящего значения
            T = 2; // TODO: инициализация подходящего значения

            expected = 0F; // TODO: инициализация подходящего значения
            actual = HMM_QPN_Accessor.integral(Ro, L, T);
            for (int j = 0; j < T; j++)
            {
                if (j == 0)
                    expected = 0.45F;
                if (j == 1)
                    expected = 0.55F;

                float epsilon = 0.0001F;
                bool correct = Math.Abs(actual[j] - expected) <= epsilon;
                Assert.AreEqual(correct, true);
            }
        }

        /// <summary>
        ///Тест для ValueFromDistribution
        ///</summary>
        [TestMethod()]
        public void ValueFromDistributionTest()
        {
            string filename = string.Empty; // TODO: инициализация подходящего значения
            HMM_QPN target = new HMM_QPN(filename); // TODO: инициализация подходящего значения
            DistributionPare[] DP = null; // TODO: инициализация подходящего значения
            double[] expected = null; // TODO: инициализация подходящего значения
            double[] actual;
            actual = target.ValueFromDistribution(DP);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Проверьте правильность этого метода теста.");
        }

        /// <summary>
        ///Тест для ProbabilityFromDistribution
        ///</summary>
        [TestMethod()]
        public void ProbabilityFromDistributionTest()
        {
            string filename = string.Empty; // TODO: инициализация подходящего значения
            HMM_QPN target = new HMM_QPN(filename); // TODO: инициализация подходящего значения
            DistributionPare[] DP = null; // TODO: инициализация подходящего значения
            double[] expected = null; // TODO: инициализация подходящего значения
            double[] actual;
            actual = target.ProbabilityFromDistribution(DP);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Проверьте правильность этого метода теста.");
        }

        ///// <summary>
        /////Тест для ProbabilityByValueAndState
        /////</summary>
        //[TestMethod()]
        //public void ProbabilityByValueAndStateTest()
        //{
        //    HMM_QPN Model = null; // TODO: инициализация подходящего значения
        //    float Value = 0F; // TODO: инициализация подходящего значения
        //    int State = 0; // TODO: инициализация подходящего значения
        //    float expected = 0F; // TODO: инициализация подходящего значения
        //    float actual;
        //    actual = HMM_QPN.ProbabilityByValueAndState(Model, Value, State);
        //    Assert.AreEqual(expected, actual);
        //    Assert.Inconclusive("Проверьте правильность этого метода теста.");
        //}

        ///// <summary>
        /////Тест для PQN_Method
        /////</summary>
        //[TestMethod()]
        //public void PQN_MethodTest()
        //{
        //    string filename = string.Empty; // TODO: инициализация подходящего значения
        //    HMM_QPN target = new HMM_QPN(filename); // TODO: инициализация подходящего значения
        //    int state_nubmer = 0; // TODO: инициализация подходящего значения
        //    int period_length = 0; // TODO: инициализация подходящего значения
        //    int stop = 0; // TODO: инициализация подходящего значения
        //    target.PQN_Method(state_nubmer, period_length, stop);
        //    Assert.Inconclusive("Невозможно проверить метод, не возвращающий значение.");
        //}

        /// <summary>
        ///Тест для MinElementOfArray
        ///</summary>
        [TestMethod()]
        public void MinElementOfArrayTest()
        {
            double[] p = { 0.7F, 0.3F, 0.1F };
            double expected = 0.1F;
            double actual;
            actual = HMM_QPN.MinElementOfArray(p);
            Assert.AreEqual(expected, actual);
            // наибольший последний   
            double[] p1 = { 0.1F, 0.3F, 0.7F };
            expected = 0.1F;
            actual = HMM_QPN.MaxElementOfArray(p1);
            Assert.AreEqual(expected, actual);
            //наибольший в середине
            double[] p2 = { 0.1F, 0.3F, 0.7F };
            expected = 0.1F;
            actual = HMM_QPN.MaxElementOfArray(p2);
            Assert.AreEqual(expected, actual);
            //всего 1 элемент
            double[] p3 = { 0.7F };
            expected = 0.1F;
            actual = HMM_QPN.MaxElementOfArray(p3);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///Тест для MaxElementOfArray
        ///</summary>
        [TestMethod()]
        public void MaxElementOfArrayTest()
        {   //  p = null
           // float[] p = null; 
           //// float expected = 0F;
           // float actual;
           // actual = HMM_QPN.MaxElementOfArray(p);
           //// Assert.F
           // Assert.Inconclusive("Проверьте правильность этого метода теста.");
            // наибольший нулевой    
            double[] p = { 0.7F, 0.3F, 0.1F };
            double expected = 0.7F;
            double actual;
            actual = HMM_QPN.MaxElementOfArray(p);
            Assert.AreEqual(expected, actual);
            // наибольший последний   
            double[] p1 = { 0.1F, 0.3F, 0.7F };
            expected = 0.7F; 
            actual = HMM_QPN.MaxElementOfArray(p1);
            Assert.AreEqual(expected, actual);
            //наибольший в середине
            double[] p2 = { 0.1F, 0.3F, 0.7F };
            expected = 0.7F;
            actual = HMM_QPN.MaxElementOfArray(p2);
            Assert.AreEqual(expected, actual);
            //всего 1 элемент
            double[] p3 = { 0.7F };
            expected = 0.7F;
            actual = HMM_QPN.MaxElementOfArray(p3);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///Тест для MatrToArr
        ///</summary>
        [TestMethod()]
        [DeploymentItem("HSMPQApplication.exe")]
        public void MatrToArrTest()
        {
            double[,] P = null; // TODO: инициализация подходящего значения
            int k = 0; // TODO: инициализация подходящего значения
            double[] expected = null; // TODO: инициализация подходящего значения
            double[] actual;
            actual = HMM_QPN_Accessor.MatrToArr(P, k);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Проверьте правильность этого метода теста.");
        }

        /// <summary>
        ///Тест для IsCorrect
        ///</summary>
        [TestMethod()]
        public void IsCorrectTest()
        {
            string filename = string.Empty; // TODO: инициализация подходящего значения
            HMM_QPN target = new HMM_QPN(filename); // TODO: инициализация подходящего значения
            int expected = 0; // TODO: инициализация подходящего значения
            int actual;
            actual = target.IsCorrect();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Проверьте правильность этого метода теста.");
        }

        /// <summary>
        ///Тест для FiPc
        ///</summary>
        [TestMethod()]
        [DeploymentItem("HSMPQApplication.exe")]
        public void FiPcTest()
        {
            double[] Ro = { 0.3F, 0.3F, 0.4F }; // TODO: инициализация подходящего значения
            int L = 3; // TODO: инициализация подходящего значения
            int T =5; // TODO: инициализация подходящего значения

            double expected = 0F; // TODO: инициализация подходящего значения
            double actual;
            for (double j = 0F; j <= T; j++)
            {
                actual = HMM_QPN_Accessor.FiPc(Ro, L, T, j);
                if (j==0F)
                    expected = 0.18F;
                if (j==1F)
                        expected = 0.18F;                
                if (j==2F)
                        expected =  0.18F;
                if (j==3F)
                        expected =  0.18F;
                if (j==4F)
                        expected =  0.24F;
                if (j==5F)
                        expected = 0.24F;
                double epsilon = 0.0001F;
                bool correct = Math.Abs(actual - expected) <= epsilon;
                Assert.AreEqual(correct, true);
            }


            L = 3; // TODO: инициализация подходящего значения
            T = 2; // TODO: инициализация подходящего значения

            expected = 0F; // TODO: инициализация подходящего значения

            for (double j = 0F; j <= T; j++)
            {
                actual = HMM_QPN_Accessor.FiPc(Ro, L, T, j);
                if (j == 0F)
                    expected = 0.45F;
                if (j == 1F)
                    expected = 0.45F;
                if (j == 2F)
                    expected = 0.6F;
                double epsilon = 0.0001F;
                bool correct = Math.Abs(actual - expected) <= epsilon;
                Assert.AreEqual(correct, true);
            }
          }

        ///// <summary>
        /////Тест для BinaryProbabilityMethod
        /////</summary>
        //[TestMethod()]
        //public void BinaryProbabilityMethodTest()
        //{
        //    //float p = 0F; // TODO: инициализация подходящего значения
        //    //int expected = 0; // TODO: инициализация подходящего значения
        //    //int actual;
        //    //actual = HMM_QPN.BinaryProbabilityMethod(p);
        //    //Assert.AreEqual(expected, actual);

        //    float p = 0.8F;
        //    int n = 1000000;
        //    float f0 = 0;
        //    float f1 = 0;

        //    int cur;
        //    for (int i = 0; i < n; i++)
        //    {
        //        cur = HMM_QPN.BinaryProbabilityMethod(p);
        //        if (cur == 0) f0++;
        //        if (cur == 1) f1++;
        //    }
        //    f0 = f0 / n;
        //    f1 = f1 / n;

        //    //p = 1F; // TODO: инициализация подходящего значения
        //    //expected = 1; // TODO: инициализация подходящего значения
        //    //actual = HMM_QPN.BinaryProbabilityMethod(p);
        //    //Assert.AreEqual(expected, actual);

        //    //p = 0.7F; // TODO: инициализация подходящего значения
        //    //expected = 1; // TODO: инициализация подходящего значения
        //    //actual = HMM_QPN.BinaryProbabilityMethod(p);
        //    //Assert.AreEqual(expected, actual);

        //    //p = 0.2F; // TODO: инициализация подходящего значения
        //    //expected = 0; // TODO: инициализация подходящего значения
        //    //actual = HMM_QPN.BinaryProbabilityMethod(p);
        //    //Assert.AreEqual(expected, actual);
        //}
    }
}
