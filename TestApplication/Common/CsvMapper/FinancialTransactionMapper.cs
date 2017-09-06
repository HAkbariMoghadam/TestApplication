using CsvHelper.Configuration;
using Domain.Entities;
using Domain.Enums;

namespace Common.CsvMapper
{
	public sealed class FinancialTransactionMapper : CsvClassMap<FinancialTransaction>
	{
		public FinancialTransactionMapper()
		{
			Map(t => t.Id).Name("Id");
			Map(t => t.Name).Name("Name");
			Map(t => t.Type).Name("Type");
			Map(t => t.Style).Name("Style");
			Map(t => t.CallPutFlag).Name("C/P");
			Map(t => t.ExpiryDate).Name("Expiry");
			Map(t => t.StrikePrice).Name("Strike price");
			Map(t => t.CCY).Name("CCY");
		}
	}
}
