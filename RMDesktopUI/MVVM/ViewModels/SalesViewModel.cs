using Caliburn.Micro;
using RMDesktopUI.Library.API;
using RMDesktopUI.Library.Helpers;
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
        IConfigHelper _configHelper;

        public SalesViewModel(IProductEndpoint ProductEndpoint, IConfigHelper configHelper)
        {
            _productEndpoint = ProductEndpoint;
            _configHelper = configHelper;
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

        private decimal calculateSubTotal()
        {
            decimal _subTotal = 0;
            // Calculate the subtotal of the cart
            foreach (var item in Cart)
            {
                _subTotal += item.Product.RetailPrice * item.QuantityInCart;
            }
            return _subTotal;
        }

        private decimal calculateTax()
        {
            decimal TaxRate = (decimal)_configHelper.GetTaxRate();
            decimal _Tax = 0;

            // Calculate the tax of the cart
            foreach (var item in Cart)
            {
                if (item.Product.IsTaxable)
                {
                    _Tax += item.Product.RetailPrice * item.QuantityInCart * (TaxRate/100);
                }
            }

            return _Tax;
        }

        public string SubTotal
        {
            get
            {
                return calculateSubTotal().ToString("C");
            }
        }

		public string Tax
        {
            get
            {
                return calculateTax().ToString("c");
            }
        }

		public string Total
        {
            get
            {
                // Calculate the total of the cart
                return (calculateSubTotal() + calculateTax()).ToString("C");
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
            CartItemModel existingCartItem = Cart.FirstOrDefault(x => x.Product.Id == SelectedProduct.Id);
            // Add the selected product to the cart
            if (existingCartItem != null)
            {
                existingCartItem.QuantityInCart += ItemQuantity;
            }
            else
            {
                CartItemModel cartItem = new CartItemModel
                {
                    Product = SelectedProduct,
                    QuantityInCart = ItemQuantity
                };
                Cart.Add(cartItem);
            }
            //prevent the user from adding the same product out of stock
            SelectedProduct.StockQuantity -= ItemQuantity;
            ItemQuantity = 0;

            //Notify the UI that the properties have changed
            NotifyOfPropertyChange(() => existingCartItem.DisplayText);
            NotifyOfPropertyChange(() => SelectedProduct.DisplayText);
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
