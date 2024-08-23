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
		private BindingList<String> _cart;
		private string _ItemQuantity;

		public BindingList<string> Products
		{
			get { return _Products; }
			set 
			{
				_Products = value; 
				NotifyOfPropertyChange(() => Products);
			}
		}

		public BindingList<String> Cart
		{
			get { return _cart; }
			set 
			{
				_cart = value;
				NotifyOfPropertyChange(() => Cart);
			}
		}

		public string ItemQuantity
		{
			get { return _ItemQuantity; }
			set 
			{
				_ItemQuantity = value;
				NotifyOfPropertyChange(() => ItemQuantity);
			}
		}

		public string SubTotal
        {
            get
            {
                // Calculate the subtotal of the cart
                return "0.00€";
            }
        }

		public string Tax
        {
            get
            {
                // Calculate the tax of the cart
                return "0.00€";
            }
        }

		public string Total
        {
            get
            {
                // Calculate the total of the cart
                return "0.00€"€;
            }
        }

		public bool CanAddToCart
        {
            get
            {
				bool output = false;
                // Make sure something is selected
				// Make sure a quantity is entered
                return output;
            }
        }

		public void AddToCart()
        {
            // Add the selected product to the cart
        }

		public bool CanRemoveFromCart
        {
            get
            {
                bool output = false;
                // Make sure something is selected
                return output;
            }
        }

		public void RemoveFromCart()
		{
			// Remove the selected product from the cart
		}

		public bool CanCheckOut
        {
            get
            {
                bool output = false;
                // Make sure the cart has something in it
                return output;
            }
        }

        public void CheckOut()
        {
            // Check out the cart
        }

	}
}
