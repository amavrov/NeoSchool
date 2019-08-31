using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NeoSchool.Areas.Administration.Models;
using NeoSchool.Services;

namespace NeoSchool.Areas.Administration.Controllers
{
    public class UserController : AdminController
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet("Administration/User/ViewAllUsers")]
        public IActionResult ViewAllUsers()
        {
            var usersAndRoles = userService.GetAllUsersAndRoles();
            return View(usersAndRoles);
        }

        [HttpPost("Administration/User/Promote")]
        public IActionResult Promote(PromoteUserInputModel model)
        {
            var user = userService.ChangeUserRole(model.Username, model.Role);
            return View();
        }
    }
}