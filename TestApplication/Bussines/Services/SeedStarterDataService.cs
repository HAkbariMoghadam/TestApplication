using Bussines.IServices;
using Data;
using System.Linq;

namespace Bussines.Services
{
    public class SeedStarterDataService : ISeedStarterDataService
    {
        public void SeedData()
        {
            using (var context = new DatabaseContext())
            {
                if (context.Companies.Count() == 0)
                {
                    var aBCINC = context.Companies.Create();

                    aBCINC.Currency = new Domain.Entities.Currency { Name = "PLN", RiskFreeRate = 5 };
                    aBCINC.Name = "ABC INC";
                    aBCINC.StockPrice = 30;
                    aBCINC.Volatility = 40;
                    context.Companies.Add(aBCINC);

                    var cDELTD = context.Companies.Create();

                    cDELTD.Currency = new Domain.Entities.Currency { Name = "USD", RiskFreeRate = 3 };
                    cDELTD.Name = "CDE LTD";
                    cDELTD.StockPrice = 110;
                    cDELTD.Volatility = 5;
                    context.Companies.Add(cDELTD);

                    context.SaveChanges();

                }
            }
        }
    }
}
