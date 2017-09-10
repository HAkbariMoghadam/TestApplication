using Common.Share.Enums;
using Domain.Entities;
using System.Collections.Generic;
using System.IO;

namespace Bussines.IServices
{
	public interface IFinantialTransactionService
	{
		List<FinancialTransaction> Calculate(Stream file, FileFormatEnum format);
	}
}
