using Microsoft.AspNetCore.Mvc;
using ProductManagementSystem.HelperMethods;
using ProductManagementSystem.Model;
using ProductManagementSystem.Model.Entities;
using ProductManagementSystem.Model.MockData;
using ProductManagementSystem.Services;
using ProductManagementSystem.ViewModels.User;

namespace Znak.Controllers
{
    [Route("")]
    public class UserController : ControllerBase
    {
        private readonly EFContext context;
        private readonly IRepository<User> userRepository;

        public UserController(IAuthenticationUser authentication, EFContext context, IRepository<User> userRepository) : base(authentication)
        {
            if (!context.Users.Any())
            {
                context.CreateMockData();
                context.SaveChanges();
            }

            this.context = context;
            this.userRepository = userRepository;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpGet(nameof(Registration))]
        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost(nameof(Registration))]
        public async Task<IActionResult> Registration(RegistrationViewModel viewModel)
        {
            try
            {
                await userRepository.CreateAsync(new User
                {
                    FirstName = viewModel.FirstName,
                    LastName = viewModel.LastName,
                    Email = viewModel.Email,
                    Address = viewModel.Address,
                    Login = viewModel.Login,
                    Password = viewModel.Password,
                    Avatar = viewModel.Avatar.ConvertIFormFileToByteArray(),
                    UserRole = UserRole.Admin
                });
                context.SaveChanges();
                return RedirectToAction(nameof(RegistrationSuccessful));
            }
            catch
            {
                return View();
            }
        }

        [HttpGet(nameof(RegistrationSuccessful))]
        public IActionResult RegistrationSuccessful()
        {
            return View();
        }

        [HttpGet(nameof(Index))]
        public async Task<IActionResult> Index()
        {
            var viewModel = new UserViewModel()
            {
                Users = await userRepository.GetAllAsync()
            };
            return View(viewModel);
        }

        [HttpGet(nameof(ViewUser))]
        public async Task<IActionResult> ViewUser(Guid id)
        {
            try
            {
                var user = await userRepository.GetByIdAsync(id);
                var viewModel = new UserViewViewModel
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    Address = user.Address,
                    Phone = user.Phone,
                    Login = user.Login,
                    Password = user.Password,
                    Avatar = user.Avatar
                };

                return View(viewModel);
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpGet(nameof(Edit))]
        public async Task<IActionResult> Edit(Guid id)
        {
            try
            {
                var user = await userRepository.GetByIdAsync(id);
                var viewModel = new UserEditViewModel
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    Address = user.Address,
                    Phone = user.Phone,
                    Login = user.Login,
                    Password = user.Password,
                    ImageBytes = user.Avatar
                };

                return View(viewModel);
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost(nameof(Edit))]
        public async Task<IActionResult> Edit(UserEditViewModel viewModel)
        {
            try
            {
                var user = await userRepository.GetByIdAsync(viewModel.Id);
                user.FirstName = viewModel.FirstName;
                user.LastName = viewModel.LastName;
                user.Email = viewModel.Email;
                user.Address = viewModel.Address;
                user.Phone = viewModel.Phone;
                user.Avatar = viewModel.Image == null ? viewModel.ImageBytes : viewModel.Image.ConvertIFormFileToByteArray();
                user.Login = viewModel.Login;
                user.Password = viewModel.Password;

                await userRepository.TrySaveAsync();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(viewModel);
            }
        }

        [HttpGet(nameof(Delete))]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await userRepository.DeleteAsync(id);
                return RedirectToAction(nameof(Deleted));
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpGet(nameof(Deleted))]
        public IActionResult Deleted()
        {
            return View();
        }
    }
}
