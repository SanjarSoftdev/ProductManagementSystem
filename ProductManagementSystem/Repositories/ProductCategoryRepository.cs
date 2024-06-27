using ProductManagementSystem.Model;
using ProductManagementSystem.Model.Entities;
using ProductManagementSystem.Services;

namespace ProductManagementSystem.Repositories
{
    public class ProductCategoryRepository : Repository<ProductCategory>
    {
        public ProductCategoryRepository(EFContext context) : base(context)
        {
        }
    }
}
