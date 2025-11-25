namespace GainsHub.Models
{
    public class CartItem
    {
        public int Id { get; set; }

        // Foreign Key for Product
        public int ProductId { get; set; }
        public Product Product { get; set; }
        
        public int Quantity { get; set; }// Quantity of the product in the cart
        public decimal UnitPrice { get; set; }// Price of the product at the time it was added to the cart        
        public decimal TotalAmount => UnitPrice * Quantity;// Total price for this CartItem (Price * Quantity)
    }
}
