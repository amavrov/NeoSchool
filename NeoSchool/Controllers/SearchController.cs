using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NeoSchool.Data;
using NeoSchool.Models;

namespace NeoSchool.Controllers
{
    public class SearchController : Controller
    {
        private readonly NeoSchoolDbContext db;

        public SearchController(NeoSchoolDbContext db)
        {
            this.db = db;
        }

        public IActionResult SearchAll()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SearchAll(string disciplineName, string grade)
        {

            var videos = db
                .VideoLessons
                .Select(x => x.Disciplines
                .Where(j => j.DisciplineName == disciplineName && j.Grade == grade))
                .ToList();
            foreach (var item in videos)
            {
                foreach (var i in item)
                {
                    var a = i.Id;
                }
            }

            return View();
        }
    }
}