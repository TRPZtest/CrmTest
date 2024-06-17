using CrmTest.Data.ApplicationIdentityData;
using Microsoft.AspNetCore.Identity;

namespace CrmTest.Identity
{
    public class IdentityConfiguration
    {
        public static async Task AddRoles(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<ApplicationRole>>();

            string[] roleNames = { "Employee", "Hr Manager", "Project Manager", "Administrator" };

            foreach (var role in roleNames)
            {
                if (!await roleManager!.RoleExistsAsync(role))
                    await roleManager.CreateAsync(new ApplicationRole(role));
            }
        }
    }
}
