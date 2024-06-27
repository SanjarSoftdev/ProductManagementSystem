using Microsoft.EntityFrameworkCore;
using ProductManagementSystem.Model;
using ProductManagementSystem.Model.Entities;
using ProductManagementSystem.Settings;

namespace ProductManagementSystem.Services
{
    public class AuthenticationUser : IAuthenticationUser
    {
        public EFContext Context { get; set; }
        public AuthenticationUser(EFContext context)
        {
            Context = context;
        }
        public bool IsLoggedIn => Setting.CurrentUser != null;

        public async Task<User> SignIn(string login, string pass)
        {
            User user = await Context.Users.FirstOrDefaultAsync(u => u.Login.ToLower() == login.ToLower() && u.Password.ToLower() == pass.ToLower());
            Setting.CurrentUser = user;
            return user;
        }

        public void SignUp()
        {
            Setting.SignUpUser = Setting.CurrentUser;
            Setting.CurrentUser = null;
        }
    }
}
