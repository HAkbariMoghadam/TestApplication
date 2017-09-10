using Bussines.IServices;
using Common.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestApplication.Models;

namespace TestApplication.Controllers
{
	public class HomeController : Controller
	{
		private IFinantialTransactionService _finantialTransactionService;
		public HomeController(IFinantialTransactionService finantialTransactionService)
		{
			_finantialTransactionService = finantialTransactionService;
		}

		[HttpGet]
		public ActionResult Index()
		{
			var model = new FinancialTransactionViewModel();
			return View(model);
		}

		[ValidateAntiForgeryToken]
		[HttpPost]
		public ActionResult Index(FinancialTransactionViewModel model)
		{
			if (ModelState.IsValid)
			{
				if (model.File?.ContentLength <= 0)
				{
					ModelState.AddModelError("FileRequired", "Please Upload A Valid File");
				}

				if (!ValidationHelpers.ValidateFileContentType(model.File?.ContentType, model.FileFormats))
				{
					ModelState.AddModelError("WrongFormat", $"You should upload a file with selected format {model.FileFormats}");
				}

				if (ModelState.IsValid)
				{
					var pricetrades = _finantialTransactionService.Calculate(model.File.InputStream, model.FileFormats);

					if (pricetrades?.Count == 0)
					{
						ModelState.AddModelError("ErrorInCalculation", "An error has been ocured, Please call administrator");
					}

					model.FinancialTransactions = pricetrades;
				}
			}

			return View(model);
		}


	}
}