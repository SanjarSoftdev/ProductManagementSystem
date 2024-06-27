namespace ProductManagementSystem.ViewModels.Product
{
    using Microsoft.AspNetCore.Http;
    using System.ComponentModel.DataAnnotations;

    public class ProductAddViewModel
    {
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

        [Required(ErrorMessage = "Please upload an image")]
        public IFormFile Image { get; set; }
    }
}
