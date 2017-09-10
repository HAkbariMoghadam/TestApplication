using System.Collections.Generic;

namespace Domain.Entities
{
	public class Currency : BaseEntity
	{
		public string Name { get; set; }
		public byte RiskFreeRate { get; set; }

		public ICollection<Company> Companies { get; set; }
	}
}
