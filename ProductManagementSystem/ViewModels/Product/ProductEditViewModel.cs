using System.ComponentModel.DataAnnotations;

namespace ProductManagementSystem.ViewModels.Product
{
    public class ProductEditViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Price must be a positive number")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Please select a category")]
        public Guid ProductCategoryId { get; set; }

        [Required(ErrorMessage = "Please select a unit")]
        public Guid UnitMeasureId { get; set; }

        public IFormFile Image { get; set; }

        public byte[] ImageBytes { get; set; }
    }
}
