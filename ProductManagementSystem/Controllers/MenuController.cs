using ProductManagementSystem.Model.Entities;
using ProductManagementSystem.Services;

namespace Znak.Controllers
{
    public class MenuController : ControllerBase
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<ProductCategory> _productCategoryRepository;
        private readonly IRepository<UnitMeasure> _unitMeasureRepository;

        public MenuController(IAuthenticationUser authentication, IRepository<Product> productRepository, IRepository<ProductCategory> productCategoryRepository, IRepository<UnitMeasure> unitMeasureRepository) : base(authentication)
        {
            _productRepository = productRepository;
            _productCategoryRepository = productCategoryRepository;
            _unitMeasureRepository = unitMeasureRepository;
        }
    }
}
