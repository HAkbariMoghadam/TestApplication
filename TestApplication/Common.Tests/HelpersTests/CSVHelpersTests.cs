using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Common.Helpers;
using Domain.Entities;
using System.IO;
using Domain.CsvMapper;

namespace Common.Tests.HelpersTests
{
    [TestClass]
    public class CSVHelpersTests
    {
        [TestMethod]
        public void ReadFileTest()
        {
            var baseDir = AppDomain.CurrentDomain.BaseDirectory;
            var filePath = Path.Combine(baseDir, "TestFiles", "CSVTestData.csv");

            var csvTestDataTextReader = new StreamReader(filePath);

            var data = CsvHelpers.ReadFile<FinancialTransaction>(csvTestDataTextReader, typeof(FinancialTransactionMapper));

            Assert.IsTrue(data?.Count > 0 && data?[0].Id == 123);
        }
    }
}
