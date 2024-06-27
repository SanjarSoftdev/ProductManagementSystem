using ProductManagementSystem.Model;
using ProductManagementSystem.Model.Entities;
using ProductManagementSystem.Services;

namespace ProductManagementSystem.Repositories
{
    public class UserRepository : Repository<User>
    {
        public UserRepository(EFContext context) : base(context)
        {
        }
    }
}
