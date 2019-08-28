using Microsoft.AspNetCore.Identity;
using NeoSchool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NeoSchool.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> userManager;

        public UserService(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<string> GetUsernameByUserId(string userId)
        {
            var user = await userManager.FindByIdAsync(userId);
            return user.UserName;
        }
    }
}
