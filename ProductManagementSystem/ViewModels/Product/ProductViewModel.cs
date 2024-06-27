namespace ProductManagementSystem.ViewModels.Product
{
    using ProductManagementSystem.Model.Entities;

    public class ProductViewModel
    {
        public IEnumerable<Product> Products { get; set; } = new List<Product>();
    }
}
