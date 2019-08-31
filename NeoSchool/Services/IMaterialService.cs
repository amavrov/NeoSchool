using NeoSchool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NeoSchool.Services
{
    public interface IMaterialService
    {
        Task<string> Create(MaterialInputModel model);

        List<MaterialViewModel> GetAllMaterials();

        Task<string> Delete(string materialId);

        Task<string> GetMaterialId();

        Task<MaterialViewModel> Details(int materialId);

        string GetShortDescription(string fullDescription);
        Task<string> CommentMaterial(MaterialCommentInputModel model);


    }
}
