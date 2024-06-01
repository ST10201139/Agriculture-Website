using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AgriConnectPlatformProject.Areas.Identity.Data;
using AgriConnectProject.Models;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("ProjectDbContextConnection") ?? throw new InvalidOperationException("Connection string 'ProjectDbContextConnection' not found.");

builder.Services.AddDbContext<ProjectDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<AgriConnectPlatformProjectUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
})
  .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ProjectDbContext>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

// Seed roles and users
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        await UserRoleInitializer.InitializeAsync(services);
    }
    catch (Exception ex)
    {
        // Handle exceptions if needed
        Console.WriteLine(ex.Message);
    }
}

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();
app.Run();
