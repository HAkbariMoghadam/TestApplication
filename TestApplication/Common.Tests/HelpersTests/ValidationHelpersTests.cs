using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using Common.Helpers;
using Common.Share.Enums;

namespace Common.Tests.HelpersTests
{
    [TestClass]
    public class ValidationHelpersTests
    {
        [TestMethod]
        public void ValidateFileContentTypeTest()
        {
            var baseDir = AppDomain.CurrentDomain.BaseDirectory;
            var filePath = Path.Combine(baseDir, "TestFiles", "XMLTestData.xml");

            FileInfo fileInfo = new FileInfo(filePath);

            Assert.IsTrue(ValidationHelpers.ValidateFileContentType(fileInfo, FileFormatEnum.XML));
        }

        [TestMethod]
        public void ValidateFileContentTypeFailTest()
        {
            var baseDir = AppDomain.CurrentDomain.BaseDirectory;
            var filePath = Path.Combine(baseDir, "TestFiles", "XMLTestData.xml");

            FileInfo fileInfo = new FileInfo(filePath);

            Assert.IsFalse(ValidationHelpers.ValidateFileContentType(fileInfo, FileFormatEnum.CSV));
        }
    }
}
