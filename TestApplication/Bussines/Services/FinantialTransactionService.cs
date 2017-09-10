using Bussines.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Threading.Tasks;
using Domain.Entities;
using System.IO;
using log4net;
using System.Reflection;
using Domain.Enums;
using Bussines.IAlgorithms;
using Common.Helpers;
using Data;
using Domain.CsvMapper;
using Common.Share.Enums;

namespace Bussines.Services
{
	public class FinantialTransactionService : IFinantialTransactionService
	{
		private readonly ILog log = LogManager.GetLogger(typeof(FinantialTransactionService));
		private readonly IBlackScholes _blackScholes;

		public FinantialTransactionService(IBlackScholes blackScholes)
		{
			_blackScholes = blackScholes;
		}
		public List<FinancialTransaction> Calculate(Stream file, FileFormatEnum format)
		{
			List<FinancialTransaction> result = new List<FinancialTransaction>();
			try
			{
				using (var textReader = new StreamReader(file))
				{
					switch (format)
					{
						case FileFormatEnum.XML:
							result = XmlHelpers.ReadFile<Portfolio>(file)?.Trade;
							break;
						case FileFormatEnum.CSV:
							result = CsvHelpers.ReadFile<FinancialTransaction>(textReader, typeof(FinancialTransactionMapper));
							break;
						default:
							break;
					}
				}

				using (var dbContext = new DatabaseContext())
				{
					//Maybe save this list to cache is better solution - somthing like redis	
					var companies = dbContext.Companies.Include(t => t.Currency).ToList();
					var currentDate = Convert.ToDateTime(ConfigurationReader.ReadAppConfig("CurrentDate", "2016, 4, 1"));
					Parallel.ForEach(result, (FinancialTransactionItem) =>
						{
							var company = companies.FirstOrDefault(t => t.Name == FinancialTransactionItem.Name.Trim());
							if (company == null)
							{
								FinancialTransactionItem.Result = "Invalid Company Name";
							}
							else
							{
								var expireDate = Convert.ToDateTime(FinancialTransactionItem.ExpiryDate);
								double yearOfExpiery = (expireDate - currentDate).TotalDays / 365.25;
                                CallPutFlag callPutFlag;
                                if (!Enum.TryParse(FinancialTransactionItem.CallPutFlag, out callPutFlag))
								{
									FinancialTransactionItem.Result = "Invalid Data";
								}
								else
								{
									FinancialTransactionItem.Price = _blackScholes.CalculateBlackScholes(callPutFlag, company.StockPrice, FinancialTransactionItem.StrikePrice, yearOfExpiery, company.Currency.RiskFreeRate, company.Volatility);
									FinancialTransactionItem.Result = "Success";
								}
							}
						});
				}


			}
			catch (Exception ex)
			{
				result = new List<FinancialTransaction>();
				log.Error($"Error occured in {this.GetType().FullName} - {MethodBase.GetCurrentMethod().Name}", ex);
			}

			return result;
		}
	}
}
