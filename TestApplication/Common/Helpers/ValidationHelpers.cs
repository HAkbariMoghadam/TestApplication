
using Domain.Enums;
using System.IO;
using System.Linq;

namespace Common.Helpers
{
	public class ValidationHelpers
	{

		public bool ValidateFileFormat(FileInfo file, FileFormatEnum format)
		{
			var result = false;
			string[] extenstions = { };
			switch (format)
			{
				case FileFormatEnum.XML:
					extenstions[0] = ".xml";
					break;
				case FileFormatEnum.CSV:
					extenstions[0] = ".csv";
					break;
				default:
					break;
			}

			if (extenstions?.Count() > 0 && extenstions.Contains(file.Extension))
			{
				result = true;
			}

			return result;
		}
	}
}
