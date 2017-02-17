using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DomainModel;
using DomainModel.interfaces;
using Microsoft.Practices.ServiceLocation;

namespace TomaszPrusik.ViewModels
{
	public class FundViewModel
	{
		private IFundService _fundService = ServiceLocator.Current.GetInstance<IFundService>();

		public List<Fund> Funds = new List<Fund>();

		public FundViewModel( FundService fundService )
		{
			_fundService = fundService;//(double.Parse( ConfigurationManager.AppSettings[""] ),double.Parse( ConfigurationManager.AppSettings[""]));
		}
		
	}
}
