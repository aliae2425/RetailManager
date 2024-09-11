namespace RMDesktopUI.Library.Models
{
    public class ProductModel
    {
        // <summary>
        // The product's unique identifier
        // </summary>
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal RetailPrice { get; set; }
        public int StockQuantity { get; set; }
        public bool IsTaxable { get; set; }
    }
}