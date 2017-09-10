using Common.Share.Enums;
using Domain.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace TestApplication.Models
{
    public class FinancialTransactionViewModel
	{
        public FinancialTransactionViewModel()
        {
            this.File = null;
			this.FileFormats = FileFormatEnum.CSV;
            FinancialTransactions = new List<FinancialTransaction>();
        }

        [Required(ErrorMessage = "Please Select Transaction File")]
		[Display(Name = "Transaction File")]
		public HttpPostedFileBase File { get; set; }

		[Required(ErrorMessage = "Please Select File Format")]
		[Display(Name = "File Formats")]
		public FileFormatEnum FileFormats { get; set; }

        public List<FinancialTransaction> FinancialTransactions { get; set; }

	}
}