using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMDesktopUI.MVVM.ViewModels
{
    public class SalesViewModel : Screen
    {
		private BindingList<string> _Products;

		public BindingList<string> Products
		{
			get { return _Products; }
			set { _Products = value; }
		}
		


	}
}
