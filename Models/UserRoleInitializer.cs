using AgriConnectPlatformProject.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;

namespace AgriConnectProject.Models
{
    public static class UserRoleInitializer
    {
        public static async Task InitializeAsync(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            var userManger = serviceProvider.GetRequiredService<UserManager<AgriConnectPlatformProjectUser>>();

            string[] roleNames = { "Super Admin", "Employee", "Farmer" };

            IdentityResult roleResult;

            foreach (var role in roleNames)
            {
                var roleExists = await roleManager.RoleExistsAsync(role);

                if (!roleExists)
                {
                    roleResult = await roleManager.CreateAsync(new IdentityRole(role));
                }



            }

            var email = "admin@gmail.com";
            var password = "Password123_";

            if (userManger.FindByEmailAsync(email).Result == null)
            {
                AgriConnectPlatformProjectUser user = new()
                {
                    Email = email,
                    UserName = email,
                   
                   

                };

                IdentityResult result = userManger.CreateAsync(user, password).Result;

                if (result.Succeeded)
                {
                    userManger.AddToRoleAsync(user,"Super Admin").Wait();
                }
            }

        }
    }
}
