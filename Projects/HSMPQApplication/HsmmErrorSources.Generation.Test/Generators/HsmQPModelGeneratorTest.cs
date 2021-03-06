﻿using System;
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
            HsmQpModel model = createSimpleModel();
            IPseudoRandomNumberGenerator randomizer = new StandartPrnGenerator();
            HsmQpModelGenerator generator = new HsmQpModelGenerator(model, randomizer);
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

        private HsmQpModel createSimpleModel()
        {
            double[,] a = { { 0, 1 }, { 1, 0 } };
            double[] pi = { 1, 0 };
            double[,] f = { { 0, 1 }, { 0, 1 } };
            double[,] b = { { 1, 0 }, { 0, 1 } };
            //double[][]rho = {} 

            HsmQpModel model = new HsmQpModel();
            model.A = a;
            model.B = b;
            model.F = f;
            model.Pi = pi;
            return model;
        }
    }
}
