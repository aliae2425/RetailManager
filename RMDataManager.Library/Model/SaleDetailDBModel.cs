using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMDataManager.Library.Model
{
    public class SaleDetailsDBModel
    {
        public int SaleId { get; set; }
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal tax { get; set; }
    }
}
