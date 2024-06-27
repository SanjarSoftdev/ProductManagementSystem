using Microsoft.AspNetCore.Mvc;
using ProductManagementSystem.Model.Entities;
using ProductManagementSystem.Services;
using ProductManagementSystem.ViewModels.Category;

namespace Znak.Controllers
{
    public class CategoryController : ControllerBase
    {
        private readonly IRepository<ProductCategory> _categoryRepository;

        public CategoryController(IAuthenticationUser authentication, IRepository<ProductCategory> categoryRepository) : base(authentication)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _categoryRepository.GetAllAsync();
            var categoryViewModel = new CategoryViewModel
            {
                ProductCategories = categories.OrderBy(s => s.Name).ToList()
            };
            return View(categoryViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CategoryViewModel viewModel)
        {
            try
            {
                await _categoryRepository.CreateAsync(viewModel.ProductCategory);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CategoryViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(nameof(Index), viewModel);
            }

            await _categoryRepository.UpdateAsync(viewModel.ProductCategory.Id, viewModel.ProductCategory);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(CategoryViewModel viewModel)
        {
            await _categoryRepository.DeleteAsync(viewModel.ProductCategory.Id);
            return RedirectToAction(nameof(Index));
        }
    }

}
