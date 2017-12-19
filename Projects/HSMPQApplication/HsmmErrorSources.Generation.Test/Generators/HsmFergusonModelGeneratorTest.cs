using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HsmmErrorSources.Generation.Generators;
using HsmmErrorSources.Generation.Models;
using HsmmErrorSources.Generation.Random;
using System.Collections.Generic;


namespace HsmmErrorSources.Generation.Test.Generators
{
    [TestClass]
    public class HsmFergusonModelGeneratorTest
    {
        [TestMethod]
        public void TestSimpleGenerate()
        {
            HsmFergusonModel model = createSimpleModel();
            IPseudoRandomNumberGenerator randomizer = new StandartPRNGenerator();
            HsmFergusonModelGenerator generator = new HsmFergusonModelGenerator(model, randomizer);
            IList<int> result = generator.Generate(10);
            Assert.AreEqual(10, result.Count);
            foreach (int i in result)
            {
                if (i % 2 == 0)
                {
                    Assert.AreEqual(0, result[i]);
                }
                else
                {
                    Assert.AreEqual(1, result[i]);
                }
            }
        }
        [TestMethod]
        public void TestGenerate()
        {
            HsmFergusonModel model = createModel();
            IPseudoRandomNumberGenerator randomizer = new StandartPRNGenerator();
            HsmFergusonModelGenerator generator = new HsmFergusonModelGenerator(model, randomizer);
            IList<int> result = generator.Generate(20);
            Assert.AreEqual(20, result.Count);
            foreach (int i in result)
            {
                if (i % 4 == 0 || i % 4 == 1)
                {
                    Assert.AreEqual(1, result[i]);
                }
                else
                {
                    Assert.AreEqual(0, result[i]);
                }
            }
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

        private HsmFergusonModel createModel()
        {
            double[,] a = { { 0, 1 }, { 1, 0 } };
            double[] pi = { 0, 1 };
            double[,] f = { { 0, 0, 1 }, { 0, 0, 1 } };
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
