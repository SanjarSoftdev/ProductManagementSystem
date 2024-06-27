using ProductManagementSystem.Model.Entities;

namespace ProductManagementSystem.Services
{
    public interface IAuthenticationUser
    {
        bool IsLoggedIn { get; }
        Task<User> SignIn(string login, string pass);
        void SignUp();
    }
}
