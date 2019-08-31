using Microsoft.AspNetCore.Identity;
using NeoSchool.Areas.Administration.Models;
using NeoSchool.Data;
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
        private readonly NeoSchoolDbContext db;

        public UserService(UserManager<User> userManager, NeoSchoolDbContext db)
        {
            this.userManager = userManager;
            this.db = db;
        }

        public bool ChangeUserRole(string username, string userRole)
        {
            var user = userManager.FindByNameAsync(username).Result;

            if (userRole == "Admin" && userManager.IsInRoleAsync(user, "Moderator").Result)
            {
                userManager.AddToRoleAsync(user, userRole);
            }
            else if (userRole == "Admin" && userManager.IsInRoleAsync(user, "User").Result)
            {
                userManager.AddToRoleAsync(user, userRole);
            }
            else if (userRole == "User" && userManager.IsInRoleAsync(user, "Moderator").Result)
            {
                userManager.RemoveFromRoleAsync(user, "Moderator");
                userManager.AddToRoleAsync(user, userRole);
            }

            return true;
        }
        public UserRoleViewModel GetAllUsersAndRoles()
        {
            var result = new UserRoleViewModel();
            List<KeyValuePair<string, string>> usersAndRoles = new List<KeyValuePair<string, string>>();

            //var a = db.UserRoles.

            var admins = userManager.GetUsersInRoleAsync("Admin");
            var moderators = userManager.GetUsersInRoleAsync("Moderator");
            var users = userManager.GetUsersInRoleAsync("User");

            foreach (var admin in admins.Result)
            {
                usersAndRoles.Add(new KeyValuePair<string, string>($"{admin.UserName}", "Admin"));
            }
            foreach (var moderator in moderators.Result)
            {
                usersAndRoles.Add(new KeyValuePair<string, string>($"{moderator.UserName}", "Moderator"));
            }
            foreach (var user in users.Result)
            {
                usersAndRoles.Add(new KeyValuePair<string, string>($"{user.UserName}", "User"));
            }

            result.UsersAndRoles = usersAndRoles;

            return result;
        }

        public async Task<string> GetUsernameByUserId(string userId)
        {
            var user = await userManager.FindByIdAsync(userId);
            return user.UserName;
        }
    }
}
