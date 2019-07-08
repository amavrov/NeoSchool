using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace NeoSchool.Controllers
{
    public class MaterialController : Controller
    {
        public IActionResult Create()
        {
            return View();
        }
    }
}