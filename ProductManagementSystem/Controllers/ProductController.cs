using Microsoft.AspNetCore.Mvc;
using ProductManagementSystem.HelperMethods;
using ProductManagementSystem.Model.Entities;
using ProductManagementSystem.Services;
using ProductManagementSystem.ViewModels.Product;

namespace Znak.Controllers
{
    public class ProductController : ControllerBase
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<ProductCategory> _productCategoryRepository;
        private readonly IRepository<UnitMeasure> _unitMeasureRepository;

        public ProductController(IAuthenticationUser authentication, IRepository<Product> productRepository, IRepository<ProductCategory> productCategoryRepository, IRepository<UnitMeasure> unitMeasureRepository) : base(authentication)
        {
            _productRepository = productRepository;
            _productCategoryRepository = productCategoryRepository;
            _unitMeasureRepository = unitMeasureRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var products = await _productRepository.GetAllAsync();
            var menuViewModel = new ProductViewModel
            {
                Products = products.OrderBy(s => s.Name).ToList()
            };
            return View(menuViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> ViewProduct(Guid id)
        {
            try
            {
                var product = await _productRepository.GetByIdAsync(id);
                var viewModel = new ProductViewViewModel
                {
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price,
                    ProductCategory = product.ProductCategory,
                    UnitMeasure = product.UnitMeasure,
                    Image = product.Image
                };

                return View(viewModel);
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        public async Task<IActionResult> AddProduct()
        {
            ViewBag.ProductCategories = await _productCategoryRepository.GetAllAsync();
            ViewBag.UnitMeasures = await _unitMeasureRepository.GetAllAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductAddViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Product product = new Product
                    {
                        Name = viewModel.Name,
                        Description = viewModel.Description,
                        Price = viewModel.Price,
                        ProductCategoryId = viewModel.ProductCategoryId,
                        UnitMeasureId = viewModel.UnitMeasureId
                    };

                    if (viewModel.Image != null)
                    {
                        product.Image = viewModel.Image.ConvertIFormFileToByteArray();
                    }

                    await _productRepository.CreateAsync(product);

                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    ModelState.AddModelError("", "Failed to add the product. Please try again later.");
                    return View(viewModel);
                }
            }

            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            try
            {
                var product = await _productRepository.GetByIdAsync(id);
                ViewBag.ProductCategories = await _productCategoryRepository.GetAllAsync();
                ViewBag.UnitMeasures = await _unitMeasureRepository.GetAllAsync();
                var viewModel = new ProductEditViewModel
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price,
                    ProductCategoryId = product.ProductCategoryId,
                    UnitMeasureId = product.UnitMeasureId,
                    ImageBytes = product.Image
                };

                return View(viewModel);
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProductEditViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var product = await _productRepository.GetByIdAsync(viewModel.Id);
                    product.Name = viewModel.Name;
                    product.Price = viewModel.Price;
                    product.Description = viewModel.Description;
                    product.Image = viewModel.Image.ConvertIFormFileToByteArray() ?? viewModel.ImageBytes;
                    product.ProductCategoryId = viewModel.ProductCategoryId;
                    product.UnitMeasureId = viewModel.UnitMeasureId;

                    await _productRepository.TrySaveAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    ModelState.AddModelError("", "Failed to edit the product. Please try again later.");
                    return View(viewModel);
                }
            }

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Deleted()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _productRepository.DeleteAsync(id);
                return RedirectToAction(nameof(Deleted));
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
