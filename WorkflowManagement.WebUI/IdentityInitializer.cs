using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using WorkflowManagement.Entities.Concrete;

namespace WorkflowManagement.WebUI
{
    public static class IdentityInitializer
    {
        public static async Task SeedData(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            var adminRole = await roleManager.FindByNameAsync("Admin");
            if (adminRole == null)
            {
                await roleManager.CreateAsync(new AppRole { Name = "Admin" });
            }

            var memberRole = await roleManager.FindByNameAsync("Member");
            if (memberRole == null)
            {
                await roleManager.CreateAsync(new AppRole { Name = "Member" });
            }

            var adminUser = await userManager.FindByNameAsync("oxir");
            if (adminUser == null)
            {
                var user = new AppUser
                {
                    FirstName = "Uğur",
                    LastName = "Timurçin",
                    UserName = "oxir",
                    Email = "oxir@oxir.com"
                };

                await userManager.CreateAsync(user, "1");
                await userManager.AddToRoleAsync(user, "Admin");
            }
        }
    }
}
