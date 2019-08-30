using NeoSchool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NeoSchool.Services
{
    public interface IDisciplineService
    {
        Discipline CreateDiscipline(string disciplineName, string grade);

        void AddDisciplineTo(Material material);

        void AddDisciplineTo(VideoLesson videoLesson);

        Discipline ReturnDisciplineOrNull(string disciplineName, string grade);

    }
}
