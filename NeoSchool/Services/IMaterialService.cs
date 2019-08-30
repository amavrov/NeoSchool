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

        string Delete(string materialId);

        string GetMaterialId();

        MaterialViewModel Details(int materialId);

        string GetShortDescription(string fullDescription);
        string CommentMaterial(MaterialCommentInputModel model);


    }
}
