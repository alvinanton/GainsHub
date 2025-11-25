namespace GainsHub.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string UserId { get; set; } // Foreign key to Identity User
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public ICollection<Order> Orders { get; set; } // Navigation property
        public ICollection<ShippingAddress> ShippingAddresses { get; set; }
        public ICollection<PaymentMethod> PaymentMethods { get; set; }
    }
}
