using Autofac;
using Bussines.Algorithms;
using Bussines.IAlgorithms;

namespace Bussines.IOC
{
	public class BussinesContainer : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterInstance(new BlackScholes()).As<IBlackScholes>();
		}
	}
}
