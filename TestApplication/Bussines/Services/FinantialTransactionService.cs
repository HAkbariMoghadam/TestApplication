using Bussines.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using System.IO;

namespace Bussines.Services
{
    public class FinantialTransactionService : IFinantialTransactionService
    {
        public List<FinancialTransaction> Calculate(TextReader file)
        {
            throw new NotImplementedException();
        }
    }
}
