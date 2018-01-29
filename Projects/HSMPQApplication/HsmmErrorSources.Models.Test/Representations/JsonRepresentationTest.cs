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

            HsmFergusonModel initialModel = new HsmFergusonModel();
            initialModel.A = a;
            initialModel.B = b;
            initialModel.F = f;
            initialModel.Pi = pi;

            JsonRepresentation<HsmFergusonModel> jsonSerializer = new JsonRepresentation<HsmFergusonModel>();
            string serializedModel = jsonSerializer.Serialize(initialModel);
            Assert.IsNotNull(serializedModel);
            HsmFergusonModel deserializedModel = jsonSerializer.Deserialize(serializedModel);
            Assert.IsNotNull(deserializedModel);
            Assert.AreEqual(initialModel.N, deserializedModel.N);
            Assert.AreEqual(initialModel.Q, deserializedModel.Q);
        }

        [TestMethod]
        public void TestSerializeHsmQp()
        {
            double[,] a = { { 0, 1 }, { 1, 0 } };
            double[] pi = { 1, 0 };
            double[,] f = { { 0, 1 }, { 0, 1 } };
            double[,] b = { { 1, 0 }, { 0, 1 } };
            double[][]rho = new double[2][];
            rho[0] = new[]
            {
                0.3D, 0.7D
            };
            rho[1] = new[]
            {
                0.3D, 0.2D, 0.5D
            };

            HsmQPModel initialModel = new HsmQPModel();
            initialModel.A = a;
            initialModel.B = b;
            initialModel.F = f;
            initialModel.Pi = pi;
            initialModel.Rho = rho;

            JsonRepresentation<HsmQPModel> jsonSerializer = new JsonRepresentation<HsmQPModel>();
            string serializedModel = jsonSerializer.Serialize(initialModel);
            Assert.IsNotNull(serializedModel);
            HsmQPModel deserializedModel = jsonSerializer.Deserialize(serializedModel);
            Assert.IsNotNull(deserializedModel);
            Assert.AreEqual(initialModel.N, deserializedModel.N);
            Assert.AreEqual(initialModel.Q, deserializedModel.Q);
        }
    }
}
