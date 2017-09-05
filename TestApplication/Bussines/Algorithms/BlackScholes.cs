using System;
using Bussines.IAlgorithms;
using Domain.Enums;

namespace Bussines.Algorithms
{
	public class BlackScholes : IBlackScholes
	{
		public BlackScholes()
		{
			// TODO: Add constructor logic here
		}

		/// <summary>
		/// Claculate Price With BlackScholes Algorithm
		/// </summary>
		/// <param name="callPutFlag">Call Put Flag => Send c or p</param>
		/// <param name="stockPrice">Stock Price</param>
		/// <param name="strikePrice">Strike Price </param>
		/// <param name="yearsToExpire">Years To Expire</param>
		/// <param name="riskFreeRate">Risk-Free Rate</param>
		/// <param name="volatilitys">Volatilitys</param>
		/// <returns></returns>
		public double CalculateBlackScholes(CallPutFlag callPutFlag, double stockPrice, double strikePrice, double yearsToExpire, double riskFreeRate, double volatilitys)
		{
			double d1 = 0.0;
			double d2 = 0.0;
			double dBlackScholes = 0.0;

			d1 = (Math.Log(stockPrice / strikePrice) + (riskFreeRate + volatilitys * volatilitys / 2.0) * yearsToExpire) / (volatilitys * Math.Sqrt(yearsToExpire));
			d2 = d1 - volatilitys * Math.Sqrt(yearsToExpire);
			if (callPutFlag == CallPutFlag.Call)
			{
				dBlackScholes = stockPrice * CND(d1) - strikePrice * Math.Exp(-riskFreeRate * yearsToExpire) * CND(d2);
			}
			else if (callPutFlag == CallPutFlag.Put)
			{
				dBlackScholes = strikePrice * Math.Exp(-riskFreeRate * yearsToExpire) * CND(-d2) - stockPrice * CND(-d1);
			}
			return dBlackScholes;
		}
		private double CND(double X)
		{
			double L = 0.0;
			double K = 0.0;
			double dCND = 0.0;
			const double a1 = 0.31938153;
			const double a2 = -0.356563782;
			const double a3 = 1.781477937;
			const double a4 = -1.821255978;
			const double a5 = 1.330274429;
			L = Math.Abs(X);
			K = 1.0 / (1.0 + 0.2316419 * L);
			dCND = 1.0 - 1.0 / Math.Sqrt(2 * Convert.ToDouble(Math.PI.ToString())) *
				Math.Exp(-L * L / 2.0) * (a1 * K + a2 * K * K + a3 * Math.Pow(K, 3.0) +
				a4 * Math.Pow(K, 4.0) + a5 * Math.Pow(K, 5.0));

			if (X < 0)
			{
				return 1.0 - dCND;
			}
			else
			{
				return dCND;
			}
		}
	}
}
