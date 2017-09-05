using Domain.Enums;

namespace Bussines.IAlgorithms
{
	public interface IBlackScholes
	{
		double CalculateBlackScholes(CallPutFlag callPutFlag, double stockPrice, double strikePrice, double yearsToExpire, double riskFreeRate, double volatilitys);
	}
}