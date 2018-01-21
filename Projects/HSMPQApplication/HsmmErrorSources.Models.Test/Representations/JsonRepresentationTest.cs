using HsmmErrorSources.Models.Models;
using HsmmErrorSources.Models.Representations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HsmmErrorSources.Models.Test.Representations
{
    [TestClass]
    public class JsonRepresentationTest
    {
        [TestMethod]
        public void TestSerializeFeguson()
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

            JsonRepresentation<HsmFergusonModel> jsonSerializer = new JsonRepresentation<HsmFergusonModel>();
            string result = jsonSerializer.Serialize(model);

        }
    }
}
