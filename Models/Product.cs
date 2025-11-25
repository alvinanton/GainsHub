using System.ComponentModel;

namespace GainsHub.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } // Name of the product
        public string Description { get; set; } // Detailed description
        public decimal Price { get; set; } // Product price
        public int StockQuantity { get; set; } // Available stock
        public string ImageUrl { get; set; } // Path to the product image
        public bool IsVisible { get; set; }
        
        public ICollection<ProductCategory> ProductCategories { get; set; }
    }
}
