using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Common.Helpers
{
	public class CsvHelpers
	{

		public static List<T> ReadFile<T>(TextReader reader, Type Mapper = null) where T : class
		{
			var configuration = new CsvConfiguration();

			if (Mapper != null)
			{
				configuration.RegisterClassMap(Mapper);
			}

			using (var csvReader = new CsvHelper.CsvReader(reader, configuration))
			{
				return csvReader.GetRecords<T>().ToList();
			}
		}
	}
}
