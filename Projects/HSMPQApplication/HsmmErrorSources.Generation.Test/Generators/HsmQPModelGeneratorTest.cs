using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HsmmErrorSources.Models.Models;
using HsmmErrorSources.Generation.Random;
using HsmmErrorSources.Generation.Generators;
using System.Collections.Generic;

namespace HsmmErrorSources.Generation.Test.Generators
{
    [TestClass]
    public class HsmQPModelGeneratorTest
    {
        [TestMethod]
        public void TestSimpleGenerate()
        {
            HsmQPModel model = createSimpleModel();
            IPseudoRandomNumberGenerator randomizer = new StandartPRNGenerator();
            HsmQPModelGenerator generator = new HsmQPModelGenerator(model, randomizer);
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

        private HsmQPModel createSimpleModel()
        {
            double[,] a = { { 0, 1 }, { 1, 0 } };
            double[] pi = { 1, 0 };
            double[,] f = { { 0, 1 }, { 0, 1 } };
            double[,] b = { { 1, 0 }, { 0, 1 } };
            //double[][]rho = {} 

            HsmQPModel model = new HsmQPModel();
            model.A = a;
            model.B = b;
            model.F = f;
            model.Pi = pi;
            return model;
        }
    }
}
