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
		[HttpGet]
		public ActionResult Index()
		{
			var model = new FinancialTransactionViewModel();
			model.Reset();
			return View(model);
		}

		[HttpPost]
		public ActionResult Index(FinancialTransactionViewModel model)
		{
			model.Reset();
			return View(model);
		}


	}
}