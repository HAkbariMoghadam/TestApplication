using Autofac;
using Autofac.Integration.Mvc;
using Bussines.IOC;
using System.Web.Mvc;

namespace TestApplication.IOC
{
	public class AutoFacContainer
	{
		public static void ConfigureContainer()
		{
			var builder = new ContainerBuilder();

			//builder.RegisterType<ShopingController>();

			builder.RegisterModule(new BussinesContainer());

			var container = builder.Build();
			DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
		}
	}
}