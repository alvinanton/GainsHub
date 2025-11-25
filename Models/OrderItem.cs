namespace GainsHub.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; } // Foreign key to Order
        public Order Order { get; set; } // Navigation property
        public int ProductId { get; set; } // Foreign key to Product
        public Product Product { get; set; } // Navigation property
        public int Quantity { get; set; } // Quantity ordered
        public decimal UnitPrice { get; set; } // Price at the time of order
        public decimal TotalAmount => UnitPrice * Quantity;
    }
}
