using Caliburn.Micro;
using RMDesktopUI.Library.API;
using RMDesktopUI.Library.Models;
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
        private BindingList<ProductModel> _Products;
		private BindingList<ProductModel> _cart;
		private int _ItemQuantity;
        private ProductModel _selectedProduct;

        IProductEndpoint _productEndpoint;

        public SalesViewModel(IProductEndpoint ProductEndpoint)
        {
            _productEndpoint = ProductEndpoint;
        }

        protected override async void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
            await LoadProducts();
        }

        public async Task LoadProducts()
        {
            var ProductList = await _productEndpoint.GetAll();
            Products = new BindingList<ProductModel>(ProductList);
        }

		public BindingList<ProductModel> Products
		{
			get { return _Products; }
			set 
			{
				_Products = value; 
				NotifyOfPropertyChange(() => Products);
			}
		}

		public BindingList<ProductModel> Cart
		{
			get { return _cart; }
			set 
			{
				_cart = value;
				NotifyOfPropertyChange(() => Cart);
			}
		}

        public ProductModel SelectedProduct
        {
            get { return _selectedProduct; }
            set { 
                _selectedProduct = value;
                NotifyOfPropertyChange(() => SelectedProduct);
            }
        }


        public int ItemQuantity
		{
			get { return _ItemQuantity; }
			set 
			{
				_ItemQuantity = value;
				NotifyOfPropertyChange(() => ItemQuantity);
                NotifyOfPropertyChange(() => CanAddToCart);
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
                return "0.00€";
            }
        }

		public bool CanAddToCart
        {
            get
            {
				bool output = false;
                // Make sure something is selected
				// Make sure a quantity is entered
                if (ItemQuantity >0 && SelectedProduct?.StockQuantity >= ItemQuantity)
                {
                    output = true; 
                }
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
