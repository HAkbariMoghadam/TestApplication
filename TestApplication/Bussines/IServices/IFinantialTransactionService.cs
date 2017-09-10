using Domain.Entities;
using Domain.Enums;
using System.Collections.Generic;
using System.IO;

namespace Bussines.IServices
{
	public interface IFinantialTransactionService
	{
		List<FinancialTransaction> Calculate(Stream file, FileFormatEnum format);
	}
}
