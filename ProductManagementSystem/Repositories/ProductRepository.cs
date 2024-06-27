using ProductManagementSystem.Model;
using ProductManagementSystem.Model.Entities;
using ProductManagementSystem.Services;

namespace ProductManagementSystem.Repositories
{
    public class ProductRepository : Repository<Product>
    {
        public ProductRepository(EFContext context) : base(context)
        {
        }
    }
}
