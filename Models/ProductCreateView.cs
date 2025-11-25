using System.ComponentModel.DataAnnotations;

namespace GainsHub.Models
{
    public class ProductCreateView
    {
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than zero.")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Stock quantity is required.")]
        [Range(0, int.MaxValue, ErrorMessage = "Stock quantity cannot be negative.")]
        public int StockQuantity { get; set; }

        [Required(ErrorMessage = "Image URL is required.")]
        public string ImageUrl { get; set; }

        /*[Required(ErrorMessage = "At least one category must be selected.")]*/
        public List<int> SelectedCategoryIds { get; set; }

        public bool IsVisible { get; set; }

        public string NewCategoryNames { get; set; } // New categories entered by the user
    }
}
