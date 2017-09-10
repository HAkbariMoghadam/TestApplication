using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using Common.Helpers;
using Domain.Entities;

namespace Common.Tests.HelpersTests
{
    [TestClass]
    public class XMLHelpersTests
    {
        [TestMethod]
        public void TestFileRead()
        {
            var baseDir = AppDomain.CurrentDomain.BaseDirectory;
            var filePath = Path.Combine(baseDir, "TestFiles", "XMLTestData.xml");

            var xmlTestDataStreamReader = new StreamReader(filePath);

            var data = XmlHelpers.ReadFile<Portfolio>(xmlTestDataStreamReader.BaseStream);

            Assert.IsTrue(data?.Trade?.Count > 0 && data?.Trade?[0].Id == 123);
        }
    }
}
