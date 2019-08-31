using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NeoSchool.Data;
using NeoSchool.Models;

namespace NeoSchool.Services
{
    public class DisciplineService : IDisciplineService
    {
        private readonly NeoSchoolDbContext db;

        public DisciplineService(NeoSchoolDbContext db)
        {
            this.db = db;
        }

        public async Task AddDisciplineTo(Discipline dicipline, Material material)
        {
            material.Disciplines.Add(dicipline);
            await db.SaveChangesAsync();
        }

        public async Task AddDisciplineTo(Discipline dicipline, VideoLesson videoLesson)
        {
            videoLesson.Disciplines.Add(dicipline);
            await db.SaveChangesAsync();
        }


        public async Task<Discipline> CreateDiscipline(string disciplineName, string grade)
        {
            Discipline newDiscipline = new Discipline()
            {
                DisciplineName = disciplineName,
                Grade = grade
            };
            this.db.Add(newDiscipline);
            await this.db.SaveChangesAsync();
            Discipline discipline = await this.db.Disciplines.LastOrDefaultAsync(x => x.DisciplineName == disciplineName && x.Grade == grade);
            return discipline;
        }

        public async Task <Discipline> ReturnDisciplineOrNull(string disciplineName, string grade)
        {
            Discipline discipline = await this.db.Disciplines.FirstOrDefaultAsync(x => x.DisciplineName == disciplineName && x.Grade == grade);
            return discipline;
        }
    }
}
