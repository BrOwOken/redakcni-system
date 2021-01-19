using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedakcniSystem.Data
{
    public class UsersService
    {
        private RoleManager<IdentityRole> roleManager;
        private UserManager<IdentityUser> userManager;
        public UsersService(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        public async Task AddAdmin(string email)
        {
            await userManager.AddToRoleAsync(await userManager.FindByEmailAsync(email), "admin");
        }
        public async Task AddRedactor(string email)
        {
            await userManager.AddToRoleAsync(await userManager.FindByEmailAsync(email), "redactor");
        }
    }
}
