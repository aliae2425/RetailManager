using RMDataManager.Library.Helper;
using RMDataManager.Library.Internal.DataAccess;
using RMDataManager.Library.Model;
using RMDesktopUI.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMDataManager.Library.DataAccess
{
    internal class SaleData
    {

        public void SaveSale(SaleModel saleInfo, string cashierId)
        {
            List<SaleDetailsDBModel> details = new List<SaleDetailsDBModel>();
            ProductData productData = new ProductData();
            double taxRate = ConfigHelper.GetTaxRate();

            //fill the sale details 
            foreach (var item in saleInfo.SaleDetails)
            {
                var detail = new SaleDetailsDBModel
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity
                };

                var productInfo = productData.GetProductById(detail.ProductId);
                
                if (productInfo == null)
                {
                    throw new Exception($"The product Id of {detail.ProductId} could not be found in the database");
                }

                detail.PurchasePrice = productInfo.RetailPrice*detail.Quantity;
                
                if(productInfo.IsTaxable)
                {
                    detail.tax = detail.PurchasePrice * (decimal)taxRate;
                }
                details.Add(detail);
            }

            SaleDBModel sale = new SaleDBModel
            {
                CashierId = cashierId,
                SubTotal = details.Sum(x => x.PurchasePrice),
                Tax = details.Sum(x => x.tax),
            };
            sale.Total = sale.SubTotal + sale.Tax;


            //Save to the database
            SQLDataAccess sql = new SQLDataAccess();
            sql.SaveData<SaleDBModel>("dbo.spSale_Insert", sale, "RMData"); //Todo : Add the stored procedure

            details.ForEach(x =>
            {
                x.SaleId = sale.Id;
                sql.SaveData<SaleDetailsDBModel>("dbo.spSaleDetails_Insert", x, "RMData"); //Todo : Add the stored procedure
            });

        }

    }
}
