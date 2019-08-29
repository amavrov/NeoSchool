using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NeoSchool.Services
{
    public interface ICloudinaryService
    {
        Task<string> UploadFileAsync(IFormFile file, string fileName);
    }
}
