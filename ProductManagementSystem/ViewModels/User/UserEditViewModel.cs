namespace ProductManagementSystem.ViewModels.User
{
    public class UserEditViewModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public IFormFile Image { get; set; }
        public byte[] ImageBytes { get; set; }
    }
}
