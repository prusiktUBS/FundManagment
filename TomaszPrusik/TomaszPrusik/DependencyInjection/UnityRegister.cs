using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel;
using DomainModel.interfaces;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;

namespace TomaszPrusik.DependencyInjection
{
	public static class UnityRegister
	{
		public static void Register()
		{
			IUnityContainer container = new UnityContainer();

			container.RegisterType<IFundService, FundService>();
			ServiceLocator.SetLocatorProvider( () => new UnityServiceLocator( container ) );
		}
	}
}
