using HSMPQApplication.InverseProblem;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using HMMQPN_Model;

namespace Tests
{
    
    
    /// <summary>
    ///Это класс теста для HMM_PSMTest, в котором должны
    ///находиться все модульные тесты HMM_PSMTest
    ///</summary>
    [TestClass()]
    public class HMM_PSMTest
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


        /// <summary>
        ///Тест для SubSequence
        ///</summary>
        [TestMethod()]
        [DeploymentItem("HSMPQApplication.exe")]
        public void SubSequenceTest()
        {
            int[] O = {0,1,2,0,1,2,3,1}; // TODO: инициализация подходящего значения
            int startIndex = 0; // TODO: инициализация подходящего значения
            int endIndex = 4; // TODO: инициализация подходящего значения
            int[] expected = {0,1,2,0,1}; // TODO: инициализация подходящего значения
            int[] actual;
            actual = HMM_PSM_Accessor.SubSequence(O, startIndex, endIndex);
            for (int i = 0; i < actual.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
            startIndex = 0;
            endIndex = 0;
            int[] expected1 = {0};
            actual = HMM_PSM_Accessor.SubSequence(O, startIndex, endIndex);
            for (int i = 0; i < actual.Length; i++)
            {
                Assert.AreEqual(expected1[i], actual[i]);
            }
            startIndex = 0;
            endIndex = -1;
            actual = HMM_PSM_Accessor.SubSequence(O, startIndex, endIndex);
                Assert.IsNull(actual);

                startIndex = -1;
                endIndex = 3;
                int[] expected3 = { 0,1,2,3 };
                actual = HMM_PSM_Accessor.SubSequence(O, startIndex, endIndex);
                for (int i = 0; i < actual.Length; i++)
                {
                    Assert.AreEqual(expected1[i], actual[i]);
                }


        }

        /// <summary>
        ///Тест для AverageErrorProbability
        ///</summary>
        [TestMethod()]
        public void AverageErrorProbabilityTest()
        {
            int[] res = null; // TODO: инициализация подходящего значения
            double expected = 0F; // TODO: инициализация подходящего значения
            double actual;
            actual = HMM_PSM.AverageErrorProbability(res);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Проверьте правильность этого метода теста.");
        }

        /// <summary>
        ///Тест для GetOutputSequence
        ///</summary>
        [TestMethod()]
        public void GetOutputSequenceTest()
        {
            string filename = "H:/аспирантура/Programs/10.12.12/HSMPQApplication/1.txt"; // TODO: инициализация подходящего значения
            int length = 5; // TODO: инициализация подходящего значения
            int[] expected = {0,0,0,0,0}; // TODO: инициализация подходящего значения
            int[] actual;
            actual = HMM_PSM.GetOutputSequence(filename, length);
            for (int i = 0; i < actual.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        /// <summary>
        ///Тест для Max_Period
        ///</summary>
        [TestMethod()]
        [DeploymentItem("HSMPQApplication.exe")]
        public void Max_PeriodTest()
        {
            HMM_QPN Model = null; // TODO: инициализация подходящего значения
            int expected = 0; // TODO: инициализация подходящего значения
            int actual;
            actual = HMM_PSM_Accessor.Max_Period(Model);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Проверьте правильность этого метода теста.");
        }

        /// <summary>
        ///Тест для MultiplicativeGroupIndicator
        ///</summary>
        [TestMethod()]
        [DeploymentItem("HSMPQApplication.exe")]
        public void MultiplicativeGroupIndicatorTest()
        {
            int Symbol = 2; // TODO: инициализация подходящего значения
            int GaluaFieldCardinality = 3; // TODO: инициализация подходящего значения
            int expected = 1; // TODO: инициализация подходящего значения
            int actual;
            actual = HMM_PSM_Accessor.MultiplicativeGroupIndicator(Symbol, GaluaFieldCardinality);
            Assert.AreEqual(expected, actual);

            Symbol = 0; // TODO: инициализация подходящего значения
            GaluaFieldCardinality = 3; // TODO: инициализация подходящего значения
            expected = 0; // TODO: инициализация подходящего значения
            actual = HMM_PSM_Accessor.MultiplicativeGroupIndicator(Symbol, GaluaFieldCardinality);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///Тест для SymbolFinalProbability
        ///</summary>
        [TestMethod()]
        public void SymbolFinalProbabilityTest()
        {
            HMM_QPN Model = null; // TODO: инициализация подходящего значения
            double fi = 0F; // TODO: инициализация подходящего значения
            int d = 0; // TODO: инициализация подходящего значения
            int i = 0; // TODO: инициализация подходящего значения
            int symbol = 0; // TODO: инициализация подходящего значения
            double expected = 0F; // TODO: инициализация подходящего значения
            double actual;
            actual = HMM_PSM.SymbolFinalProbability(Model, fi, d, i, symbol);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Проверьте правильность этого метода теста.");
        }

        /// <summary>
        ///Тест для alpha
        ///</summary>
        [TestMethod()]
        [DeploymentItem("HSMPQApplication.exe")]
        public void alphaTest()
        {
            HMM_QPN Model = null; // TODO: инициализация подходящего значения
            int[] O = null; // TODO: инициализация подходящего значения
            int d = 0; // TODO: инициализация подходящего значения
            int i = 0; // TODO: инициализация подходящего значения
            int t = 0; // TODO: инициализация подходящего значения
            double expected = 0F; // TODO: инициализация подходящего значения
            double actual;
            actual = HMM_PSM_Accessor.alpha(Model, O, d, i, t);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Проверьте правильность этого метода теста.");
        }

        /// <summary>
        ///Тест для b
        ///</summary>
        [TestMethod()]
        [DeploymentItem("HSMPQApplication.exe")]
        public void bTest()
        {
            HMM_QPN Model = new HMM_QPN("H:/аспирантура/Programs/10.12.12/HSMPQApplication/13.01.txt");
            int[] O = { 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0 };
            int i = 0; // TODO: инициализация подходящего значения
            int t = 25; // TODO: инициализация подходящего значения
            double expected = 0.0000066483263599150104576F; // TODO: инициализация подходящего значения
            double actual;
            actual = HMM_PSM_Accessor.b(Model, O, i, t, O.Length);
            double epsilon = 0.00000001F;
            bool correct = Math.Abs(actual - expected) <= epsilon;
            Assert.AreEqual(correct, true);
        }

        /// <summary>
        ///Тест для LikelihoodExtended
        ///</summary>
        [TestMethod()]
        public void LikelihoodExtendedTest()
        {
            HMM_QPN Model = new HMM_QPN("F:/аспирантура/Programs/10.12.12/HSMPQApplication/M_1.txt");
            int[] O = { 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0 };  // TODO: инициализация подходящего значения
            double expected = 0F; // TODO: инициализация подходящего значения
            double actual;
            actual = HMM_PSM.LikelihoodExtended(Model, O);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Проверьте правильность этого метода теста.");
        }

        /// <summary>
        ///Тест для LikelihoodExtended1
        ///</summary>
        [TestMethod()]
        public void LikelihoodExtended1Test()
        {
            HMM_QPN Model = null; // TODO: инициализация подходящего значения
            int[] O = null; // TODO: инициализация подходящего значения
            double expected = 0F; // TODO: инициализация подходящего значения
            double actual;
            actual = HMM_PSM.LikelihoodExtended1(Model, O);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Проверьте правильность этого метода теста.");
        }
    }
}
