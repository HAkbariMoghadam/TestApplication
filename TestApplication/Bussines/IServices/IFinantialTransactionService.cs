using Domain.Entities;
using System.Collections.Generic;
using System.IO;

namespace Bussines.IServices
{
    public interface IFinantialTransactionService
    {
        List<FinancialTransaction> Calculate(TextReader file);
    }
}
