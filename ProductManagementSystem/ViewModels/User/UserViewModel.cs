namespace ProductManagementSystem.ViewModels.User
{
    using ProductManagementSystem.Model.Entities;

    public class UserViewModel
    {
        public IEnumerable<User> Users { get; set; } = new List<User>();
    }
}
