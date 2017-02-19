using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel;
using DomainModel.interfaces;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using TomaszPrusik.ModelOperations;

namespace TomaszPrusik.DependencyInjection
{
	public static class UnityRegister
	{
		public static void Register()
		{
			IUnityContainer container = new UnityContainer();

			container.RegisterType<IFundService, FundService>();
		    container.RegisterType<IOperations, Operations>();
			ServiceLocator.SetLocatorProvider( () => new UnityServiceLocator( container ) );
		}
	}
}
