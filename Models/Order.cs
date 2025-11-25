namespace GainsHub.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; } // When the order was placed
        public string Status { get; set; } // Pending, Shipped, Delivered, etc.
        public int CustomerId { get; set; } // Foreign key to Customer
        public Customer Customer { get; set; } // Navigation property
        public ICollection<OrderItem> OrderItems { get; set; } // Navigation property
        public ICollection<CartItem> CartItems { get; set; } // List of CartItems in the order
        public string ShippingAddress { get; set; } // Nullable address
        public int? ShippingAddressId { get; set; } // Foreign key for shipping address
        public ShippingAddress ShippingAddressDetails { get; set; } // Navigation to ShippingAddress model
        public int? PaymentMethodId { get; set; } // Foreign key for payment method
        public PaymentMethod PaymentMethodDetails { get; set; } // Navigation to PaymentMethod model

        // Total amount of the order items
        public decimal TotalAmount
        {
            get
            {
                // Summing the total price for all order items
                return OrderItems.Sum(item => item.TotalAmount);
            }
        }
    }
}
