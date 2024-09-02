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
		private BindingList<CartItemModel> _cart = new BindingList<CartItemModel>();
		private int _ItemQuantity;
        private ProductModel _selectedProduct;

        Decimal _subTotal = 0;
        Decimal _Tax = 0;
        Decimal _Total = 0;

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

		public BindingList<CartItemModel> Cart
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
                foreach (var item in Cart)
                {
                    _subTotal += item.Product.RetailPrice * item.QuantityInCart;
                }
                return _subTotal.ToString("C");
            }
        }

		public string Tax
        {
            get
            {
                // Calculate the tax of the cart
                _Tax = _subTotal * 1.10m;

                return _Tax.ToString("c");
            }
        }

		public string Total
        {
            get
            {
                // Calculate the total of the cart
                return (_Tax + _subTotal).ToString("C");
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
            CartItemModel cartItem = new CartItemModel
            {
                Product = SelectedProduct,
                QuantityInCart = ItemQuantity
            };
            Cart.Add(cartItem);
            NotifyOfPropertyChange(() => SubTotal);
            NotifyOfPropertyChange(() => Tax);
            NotifyOfPropertyChange(() => Total);
            NotifyOfPropertyChange(() => CanCheckOut);
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
            NotifyOfPropertyChange(() => SubTotal);
            NotifyOfPropertyChange(() => Tax);
            NotifyOfPropertyChange(() => Total);
            NotifyOfPropertyChange(() => CanCheckOut);
        }

		public bool CanCheckOut
        {
            get
            {
                bool output = false;
                if (Cart.Count > 0)
                {
                    output = true;
                }
                return output;
            }
        }

        public void CheckOut()
        {
            // Check out the cart
        }

	}
}
