using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bussines.Algorithms;
using Data;

namespace TestApplication.Tests.AlgorithmsTests
{
    [TestClass]
    public class BlackScholesTests
    {
        [TestMethod]
        public void CalculateTest()
        {
            var algorithm = new BlackScholes();

            var data = algorithm.CalculateBlackScholes(Domain.Enums.CallPutFlag.C, 30, 20, 1, 5, 40);

            Assert.AreEqual(30, data);
        }
    }
}
