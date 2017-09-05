using Domain.Enums;
using System;

namespace Domain.Entities
{
	public class FinancialTransactio
	{
		public long  Id { get; set; }
		public string Name { get; set; }
		public string Type { get; set; }
		public string Style { get; set; }
		public string CallPutFlag { get; set; }
		public DateTime ExpiryDate { get; set; }
		public int StrikePrice { get; set; }
		public Currency CCY { get; set; }
	}
}
