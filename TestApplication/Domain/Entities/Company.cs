using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
	public class Company : BaseEntity
	{
		public string Name { get; set; }
		public double StockPrice { get; set; }
		public double Volatility { get; set; }

		public long CurrencyId { get; set; }

		[ForeignKey(nameof(CurrencyId))]
		public Currency Currency { get; set; }
	}
}
