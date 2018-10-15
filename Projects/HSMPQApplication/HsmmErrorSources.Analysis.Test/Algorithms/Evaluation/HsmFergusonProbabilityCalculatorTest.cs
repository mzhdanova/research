using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HsmmErrorSources.Models.Models;
using HsmmErrorSources.Analysis.Algorithms.Evaluation;
using System.Collections.Generic;

namespace HsmmErrorSources.Analysis.Test.Algorithms.Evaluation
{
    [TestClass]
    public class HsmFergusonProbabilityCalculatorTest
    {
        [TestMethod]
        public void TestSimpleCalculate()
        {
            HsmFergusonModel model = createSimpleModel();
            int[] sequenceArr = { 0, 1, 0, 1, 0, 1, 0, 1, 0, 1 };
            List<int> sequence =new List<int>(sequenceArr);
            HsmFergusonProbabilityCalculator calculator = new HsmFergusonProbabilityCalculator(model, sequence);
            double result = calculator.Calculate();
            Assert.AreEqual(1, result);
        }

        private HsmFergusonModel createSimpleModel()
        {
            double[,] a = { { 0, 1 }, { 1, 0 } };
            double[] pi = { 1, 0 };
            double[,] f = { { 0, 1 }, { 0, 1 } };
            double[,] b = { { 1, 0 }, { 0, 1 } };

            HsmFergusonModel model = new HsmFergusonModel();
            model.A = a;
            model.B = b;
            model.F = f;
            model.Pi = pi;
            return model;
        }

    }
}
