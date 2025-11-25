namespace GainsHub.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } // Name of the category
        
        public ICollection<ProductCategory> ProductCategories { get; set; }
    }
}
