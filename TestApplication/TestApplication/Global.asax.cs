using Autofac;
using Autofac.Core;
using Bussines.IServices;
using System;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using TestApplication.IOC;

namespace TestApplication
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private static IContainer Container { get; set; }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AutoFacContainer.ConfigureContainer();
            var SeedStarterDataService = DependencyResolver.Current.GetService<ISeedStarterDataService>();
            SeedStarterDataService.SeedData();

        }

    }
}
