using NeoSchool.Areas.Administration.Models;
using NeoSchool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NeoSchool.Services
{
    public interface IUserService
    {
        Task<string> GetUsernameByUserId(string userId);

        UserRoleViewModel GetAllUsersAndRoles();

        bool ChangeUserRole(string username, string userRole);

    }
}
