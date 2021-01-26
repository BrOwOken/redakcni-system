using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace RedakcniSystem.Data
{
    public class UsersService
    {
        private RoleManager<IdentityRole> roleManager;
        private UserManager<IdentityUser> userManager;
        //private ApplicationDbContext dbContext;
        private readonly IHttpContextAccessor httpContextAccessor;
        public UsersService(IHttpContextAccessor httpContextAccessor, RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            this.httpContextAccessor = httpContextAccessor;
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
        public string GetCurrentUserId()
        {
            var id = userManager.GetUserId(httpContextAccessor.HttpContext.User);
            return id;
        }
    }
}
