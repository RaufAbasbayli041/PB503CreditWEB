using CredidSystem.Entity;
using Microsoft.AspNetCore.Identity;

namespace CredidSystem.Helpers
{
    public static class DBHelper
    {
        public static async Task SetRoles(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<User>>();

            string[] roleNames = { "Admin", "Employee", "Customer" };

            foreach (var roleName in roleNames)
            {
                var roleExist = await roleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    // Create the roles and seed them to the database
                    await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            string adminEmail = "admin@admin.com";
            string adminPassword = "Admin@123";

          
        }
    }
}
