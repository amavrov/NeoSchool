using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public void AddDisciplineTo(Discipline dicipline, Material material)
        {
            material.Disciplines.Add(dicipline);
            db.SaveChanges();
        }

        public void AddDisciplineTo(Discipline dicipline, VideoLesson videoLesson)
        {
            videoLesson.Disciplines.Add(dicipline);
            db.SaveChanges();
        }

        public void AddDisciplineTo(Material material)
        {
            throw new NotImplementedException();
        }

        public void AddDisciplineTo(VideoLesson videoLesson)
        {
            throw new NotImplementedException();
        }

        public Discipline CreateDiscipline(string disciplineName, string grade)
        {
            Discipline newDiscipline = new Discipline()
            {
                DisciplineName = disciplineName,
                Grade = grade
            };
            this.db.Add(newDiscipline);
            this.db.SaveChanges();
            Discipline discipline = this.db.Disciplines.LastOrDefault(x => x.DisciplineName == disciplineName && x.Grade == grade);
            return discipline;
        }

        public Discipline ReturnDisciplineOrNull(string disciplineName, string grade)
        {
            Discipline discipline = this.db.Disciplines.FirstOrDefault(x => x.DisciplineName == disciplineName && x.Grade == grade);
            return discipline;
        }
    }
}
