using AgriConnectPlatformProject.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AgriConnectPlatformProject.Models;

namespace AgriConnectPlatformProject.Areas.Identity.Data;

public class ProjectDbContext : IdentityDbContext<AgriConnectPlatformProjectUser>
{
    public ProjectDbContext(DbContextOptions<ProjectDbContext> options)
        : base(options)
    {
    }
    /// <summary>
    /// Dbsets for my Models 
    /// To transfer data to the database
    /// </summary>
    public DbSet<Farmer> Farmers { get; set; }

    public DbSet<Products> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }

}
