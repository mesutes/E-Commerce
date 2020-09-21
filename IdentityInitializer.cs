using E_Commerce.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce
{
    public class IdentityInitializer
    {
        public static void CreateAdminUser(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            AppUser appUser = new AppUser
            {
                Name = "Mesut",
                SurName = "Es",
                UserName = "Mesut"

            };
            if (userManager.FindByNameAsync("Mesut").Result == null)
            {
                var identityresut = userManager.CreateAsync(appUser,"Aa.dioeraclea1").Result;
            }

            if (roleManager.FindByNameAsync("Admin").Result == null)
            {
                IdentityRole role = new IdentityRole("Admin");
                var identityresult = roleManager.CreateAsync(role).Result;


                userManager.AddToRoleAsync(appUser, role.Name);

            }
        }
    }
}
