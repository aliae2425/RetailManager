using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RMDataManager.Library.Models
{
    public class SalesDetailsModels
    {
        public int SaleId { get; set; }
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public decimal purchasePrice { get; set; }
        public decimal tax { get; set; }
    }
}