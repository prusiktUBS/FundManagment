using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DomainModel;
using DomainModel.interfaces;

namespace TomaszPrusik.ViewModels
{
	public class FundViewModel
	{
		private readonly IFundService _fundService;

		public List<Fund> Funds = new List<Fund>();

		public FundViewModel( )
		{ 
			_fundService = new FundService(double.Parse( ConfigurationManager.AppSettings[""] ),double.Parse( ConfigurationManager.AppSettings[""]));
		}
		
	}
}
