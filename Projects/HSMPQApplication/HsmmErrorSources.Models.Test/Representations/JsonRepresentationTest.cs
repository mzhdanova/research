using HsmmErrorSources.Models.Models;
using HsmmErrorSources.Models.Representations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HsmmErrorSources.Models.Test.Representations
{
    [TestClass]
    public class JsonRepresentationTest
    {
        [TestMethod]
        public void TestSerializeFeguson()
        {
            double[,] a = {{0, 1}, {1, 0}};
            double[] pi = {1, 0};
            double[,] f = {{0, 1}, {0, 1}};
            double[,] b = {{1, 0}, {0, 1}};

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
            CollectionAssert.AreEqual(initialModel.A, deserializedModel.A);
            CollectionAssert.AreEqual(initialModel.B, deserializedModel.B);
            CollectionAssert.AreEqual(initialModel.F, deserializedModel.F);
            CollectionAssert.AreEqual(initialModel.Pi, deserializedModel.Pi);
        }

        [TestMethod]
        public void TestSerializeHsmQp()
        {
            double[,] a = {{0, 1}, {1, 0}};
            double[] pi = {1, 0};
            double[,] f = {{0, 1}, {0, 1}};
            double[,] b = {{1, 0}, {0, 1}};
            double[] per = {1, 0};
            double[][] rho = new double[2][];
            rho[0] = new[]
            {
                0.3D, 0.7D
            };
            rho[1] = new[]
            {
                0.3D, 0.2D, 0.5D
            };

            HsmQpModel initialModel = new HsmQpModel();
            initialModel.A = a;
            initialModel.B = b;
            initialModel.F = f;
            initialModel.Pi = pi;
            initialModel.Rho = rho;
            initialModel.Per = per;

            JsonRepresentation<HsmQpModel> jsonSerializer = new JsonRepresentation<HsmQpModel>();
            string serializedModel = jsonSerializer.Serialize(initialModel);
            Assert.IsNotNull(serializedModel);
            HsmQpModel deserializedModel = jsonSerializer.Deserialize(serializedModel);
            Assert.IsNotNull(deserializedModel);
            Assert.AreEqual(initialModel.N, deserializedModel.N);
            Assert.AreEqual(initialModel.Q, deserializedModel.Q);
            CollectionAssert.AreEqual(initialModel.A, deserializedModel.A);
            CollectionAssert.AreEqual(initialModel.B, deserializedModel.B);
            CollectionAssert.AreEqual(initialModel.F, deserializedModel.F);
            CollectionAssert.AreEqual(initialModel.Per, deserializedModel.Per);
            CollectionAssert.AreEqual(initialModel.Pi, deserializedModel.Pi);
            Assert.AreEqual(initialModel.Rho.Length, deserializedModel.Rho.Length);
            CollectionAssert.AreEqual(initialModel.Rho[0], deserializedModel.Rho[0]);
            CollectionAssert.AreEqual(initialModel.Rho[1], deserializedModel.Rho[1]);
        }
    }
}