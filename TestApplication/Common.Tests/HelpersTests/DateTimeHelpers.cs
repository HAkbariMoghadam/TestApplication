using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Common.Helpers;

namespace Common.Tests.HelpersTests
{
	[TestClass]
	public class DateTimeHelpers
	{
		[TestMethod]
		public void TestYearsDiffrent()
		{
			var current = DateTime.Now;
			var YearPast = current.AddYears(-1);

			var diffrent = current.YearsDiffrent(YearPast);

			Assert.AreEqual(1, diffrent,0.1);
		}
	}
}
