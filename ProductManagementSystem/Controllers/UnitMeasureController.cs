using Microsoft.AspNetCore.Mvc;
using ProductManagementSystem.Services;
using ProductManagementSystem.Model.Entities;
using ProductManagementSystem.ViewModels.UnitMeasure;

namespace Znak.Controllers
{
    public class UnitMeasureController : ControllerBase
    {
        private readonly IRepository<UnitMeasure> _unitMeasureRepository;

        public UnitMeasureController(IAuthenticationUser authentication, IRepository<UnitMeasure> unitMeasureRepository) : base(authentication)
        {
            _unitMeasureRepository = unitMeasureRepository;
        }

        public async Task<IActionResult> Index()
        {
            var unitMeasures = await _unitMeasureRepository.GetAllAsync();
            var unitMeasureViewModel = new UnitMeasureViewModel
            {
                UnitMeasures = unitMeasures.ToList()
            };
            return View(unitMeasureViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(UnitMeasureViewModel viewModel)
        {
            try
            {
                await _unitMeasureRepository.CreateAsync(viewModel.UnitMeasure);
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UnitMeasureViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", viewModel);
            }

            await _unitMeasureRepository.UpdateAsync(viewModel.UnitMeasure.Id, viewModel.UnitMeasure);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(UnitMeasureViewModel viewModel)
        {
            await _unitMeasureRepository.DeleteAsync(viewModel.UnitMeasure.Id);
            return RedirectToAction("Index");
        }
    }
}
