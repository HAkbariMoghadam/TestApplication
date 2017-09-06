using Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestApplication.Models
{
	public class FinancialTransactionViewModel
	{
		[Required(ErrorMessage = "Please Select Transaction File")]
		[Display(Name = "Transaction File")]
		public HttpPostedFileBase File { get; set; }

		[Required(ErrorMessage = "Please Select File Format")]
		[Display(Name = "File Formats")]
		public FileFormatEnum FileFormats { get; set; }



		public void Reset()
		{
			this.File = null;
			this.FileFormats = FileFormatEnum.CSV;
		}

	}
}