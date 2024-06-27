namespace ProductManagementSystem.Model
{
    public static class Helper
    {
        public static string DBConnection = $"Server={Environment.MachineName};Database=ProductManagementSystem;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
    }
}
