﻿using Autofac;
using Bussines.Algorithms;
using Bussines.IAlgorithms;
using Bussines.IServices;
using Bussines.Services;

namespace Bussines.IOC
{
	public class BussinesContainer : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterInstance(new BlackScholes()).As<IBlackScholes>();
			builder.RegisterType(typeof(FinantialTransactionService)).As<IFinantialTransactionService>();
            builder.RegisterInstance(new SeedStarterDataService()).As<ISeedStarterDataService>();
		}
	}
}
