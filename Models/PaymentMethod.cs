namespace GainsHub.Models
{
    public class PaymentMethod
    {
        public int Id { get; set; }
        public int CustomerId { get; set; } // Foreign key to Customer
        public Customer Customer { get; set; } // Navigation property
        public string CardNumber { get; set; } // Example: for credit card
        public string ExpiryDate { get; set; } // Expiration date for credit card
        public string CardHolderName { get; set; } // Cardholder's name
        public string PaymentType { get; set; } // E.g., "CreditCard", "PayPal", etc.
    }
}
