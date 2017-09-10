
using Common.Share.Enums;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Common.Helpers
{
	public class ValidationHelpers
	{

		public static bool ValidateFileContentType(FileInfo file, FileFormatEnum format)
		{
			return ValidateFileContentType(MimeMapping.GetMimeMapping(file.Name), format);
		}

		public static bool ValidateFileContentType(string fileContentType, FileFormatEnum format)
		{
			var result = false;
			var extenstions = GetExtentions(format);

			if (extenstions?.Count() > 0 && extenstions.Contains(fileContentType))
			{
				result = true;
			}

			return result;
		}


		private static List<string> GetExtentions(FileFormatEnum format)
		{
			List<string> extenstions = new List<string>();
			switch (format)
			{
				case FileFormatEnum.XML:
					extenstions.Add("application/xml");
					extenstions.Add("text/xml");
					break;
				case FileFormatEnum.CSV:
					extenstions.Add("text/csv");
					extenstions.Add("application/vnd.ms-excel");
					break;
				default:
					break;
			}

			return extenstions;
		}
	}
}
