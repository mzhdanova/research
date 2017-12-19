using HSMPQApplication.InverseProblem;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using HMMQPN_Model;

namespace Tests
{
    
    
    /// <summary>
    ///Это класс теста для LikelihoodTest, в котором должны
    ///находиться все модульные тесты LikelihoodTest
    ///</summary>
    [TestClass()]
    public class LikelihoodTest
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
        ///Тест для Probability
        ///</summary>
        [TestMethod()]
        public void ProbabilityTest()
        {
            int[] o = null; // TODO: инициализация подходящего значения
            HMM_QPN model = null; // TODO: инициализация подходящего значения
            Likelihood target = new Likelihood(o, model); // TODO: инициализация подходящего значения
            int t = 0; // TODO: инициализация подходящего значения
            double expected = 0F; // TODO: инициализация подходящего значения
            double actual;
            actual = target.Probability(t);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Проверьте правильность этого метода теста.");
        }

        /// <summary>
        ///Тест для FullProbability
        ///</summary>
        [TestMethod()]
        public void FullProbabilityTest()
        {
            int[] o = null; // TODO: инициализация подходящего значения
            HMM_QPN model = null; // TODO: инициализация подходящего значения
            Likelihood target = new Likelihood(o, model); // TODO: инициализация подходящего значения
            int t = 0; // TODO: инициализация подходящего значения
            double expected = 0F; // TODO: инициализация подходящего значения
            double actual;
            actual = target.FullProbability(t);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Проверьте правильность этого метода теста.");
        }

        /// <summary>
        ///Тест для Alpha
        ///</summary>
        [TestMethod()]
        public void AlphaTest()
        {
            int[] o = null; // TODO: инициализация подходящего значения
            HMM_QPN model = null; // TODO: инициализация подходящего значения
            Likelihood target = new Likelihood(o, model); // TODO: инициализация подходящего значения
            int i = 0; // TODO: инициализация подходящего значения
            int d = 0; // TODO: инициализация подходящего значения
            int t = 0; // TODO: инициализация подходящего значения
            double expected = 0F; // TODO: инициализация подходящего значения
            double actual;
            actual = target.Alpha(i, d, t);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Проверьте правильность этого метода теста.");
        }

        /// <summary>
        ///Тест для b
        ///</summary>
        [TestMethod()]
        public void bTest()
        {
            int[] o = {0,0,1,0,0,0,0,0,0,0};
            HMM_QPN model = new HMM_QPN("G:/аспирантура/Programs/10.12.12/HSMPQApplication/m_1.txt"); 

            Likelihood target = new Likelihood(o, model);
            int i = 0; // TODO: инициализация подходящего значения
            int d = 10; // TODO: инициализация подходящего значения
            int t = 8; // TODO: инициализация подходящего значения
            double expected = 0.03774874F; // TODO: инициализация подходящего значения
            double actual;
            //actual = target.b(i, d, t);
            //Assert.AreEqual(expected, actual);
            i = 0; // TODO: инициализация подходящего значения
            d = 10; // TODO: инициализация подходящего значения
            t = 13; // TODO: инициализация подходящего значения
            expected = 0.2097152F; // TODO: инициализация подходящего значения
            actual=0;
            //actual = target.b(i, d, t);
            //Assert.AreEqual(expected, actual);
           // Assert.Inconclusive("Проверьте правильность этого метода теста.");
            int[] o1 = { 0, 0};
            Likelihood target1 = new Likelihood(o1, model);
            i = 0; // TODO: инициализация подходящего значения
            d = 10; // TODO: инициализация подходящего значения
            t = 2; // TODO: инициализация подходящего значения
            expected = 0.2097152F; // TODO: инициализация подходящего значения
            actual = 0;
            actual = target1.b(i, d, t);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Проверьте правильность этого метода теста.");
        }

        /// <summary>
        ///Тест для Конструктор Likelihood
        ///</summary>
        [TestMethod()]
        public void LikelihoodConstructorTest()
        {
            int[] o = null; // TODO: инициализация подходящего значения
            HMM_QPN model = null; // TODO: инициализация подходящего значения
            Likelihood target = new Likelihood(o, model);
            Assert.Inconclusive("TODO: реализуйте код для проверки целевого объекта");
        }

        /// <summary>
        ///Тест для MultiplicativeGroupIndicator
        ///</summary>
        [TestMethod()]
        [DeploymentItem("HSMPQApplication.exe")]
        public void MultiplicativeGroupIndicatorTest()
        {
            int Symbol = 0; // TODO: инициализация подходящего значения
            int GaluaFieldCardinality = 0; // TODO: инициализация подходящего значения
            int expected = 0; // TODO: инициализация подходящего значения
            int actual;
            actual = Likelihood_Accessor.MultiplicativeGroupIndicator(Symbol, GaluaFieldCardinality);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Проверьте правильность этого метода теста.");
        }
    }
}
