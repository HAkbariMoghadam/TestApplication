using Autofac;
using Autofac.Integration.Mvc;
using Bussines.IOC;
using System.Web.Mvc;
using TestApplication.Controllers;

namespace TestApplication.IOC
{
	public class AutoFacContainer
	{
		public static void ConfigureContainer()
		{
			var builder = new ContainerBuilder();

            builder.RegisterModule(new BussinesContainer());

            builder.RegisterType<HomeController>();

			var container = builder.Build();
			DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
		}
	}
}