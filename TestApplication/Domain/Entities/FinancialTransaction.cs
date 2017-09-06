using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Domain.Entities
{
	[XmlRoot(ElementName = "trade")]
	public class FinancialTransaction
	{
		[XmlAttribute(AttributeName = "id")]
		public long Id { get; set; }
		[XmlAttribute(AttributeName = "name")]
		public string Name { get; set; }
		[XmlAttribute(AttributeName = "type")]
		public string Type { get; set; }
		[XmlAttribute(AttributeName = "style")]
		public string Style { get; set; }
		[XmlAttribute(AttributeName = "cp")]
		public string CallPutFlag { get; set; }
		[XmlAttribute(AttributeName = "expiry")]
		public string ExpiryDate { get; set; }
		[XmlAttribute(AttributeName = "strike")]
		public int StrikePrice { get; set; }
		[XmlAttribute(AttributeName = "ccy")]
		public string CCY { get; set; }
	}

	[XmlRoot(ElementName = "portfolio")]
	public class Portfolio
	{
		[XmlElement(ElementName = "trade")]
		public List<FinancialTransaction> Trade { get; set; }
	}
}
