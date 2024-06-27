using ProductManagementSystem.Model;
using ProductManagementSystem.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var services = builder.Services;
services.AddMvc(op => { op.EnableEndpointRouting = false; });
services.AddControllers();
services.AddRazorPages();
services.AddTransient<IAuthenticationUser, AuthenticationUser>();
services.AddTransient(typeof(IRepository<>), typeof(Repository<>));

services.AddControllersWithViews();

services.AddDbContext<EFContext>();

services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");

    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseAuthentication();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
