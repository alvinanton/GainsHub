namespace GainsHub.Models
{
    public class ShippingAddress
    {
        public int Id { get; set; }
        public int CustomerId { get; set; } // Foreign key to Customer
        public Customer Customer { get; set; } // Navigation property
        public string Street { get; set; } // Street name
        public string City { get; set; } // City name
        public string State { get; set; } // State or region
        public string PostalCode { get; set; } // Postal/Zip code
        public string Country { get; set; } // Country
    }
}
