using NeoSchool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NeoSchool.Services
{
    public interface IDisciplineService
    {

        Task AddDisciplineTo(Discipline dicipline, Material material);
        Task AddDisciplineTo(Discipline dicipline, VideoLesson videoLesson);
        Task<Discipline> CreateDiscipline(string disciplineName, string grade);
        Task<Discipline> ReturnDisciplineOrNull(string disciplineName, string grade);

    }
}
