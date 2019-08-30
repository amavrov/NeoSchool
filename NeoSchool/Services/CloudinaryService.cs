using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace NeoSchool.Services
{
    public class CloudinaryService : ICloudinaryService
    {
        private readonly Cloudinary cloudinaryUtility;

        public CloudinaryService(Cloudinary cloudinaryUtility)
        {
            this.cloudinaryUtility = cloudinaryUtility;
        }

        public async Task<string> UploadFileAsync(IFormFile file, string fileName)
        {
            byte[] destinationData;
            string ext = file.FileName.Split('.').Last().ToString();
            using (var ms = new MemoryStream())
            {
                await file.CopyToAsync(ms);
                destinationData = ms.ToArray();
            }

            UploadResult uploadResult = null;

            using (var ms = new MemoryStream(destinationData))
            {

                RawUploadParams uploadParams = new RawUploadParams
                {
                    Folder = "materials",
                    File = new FileDescription(fileName, ms),
                    PublicId = Guid.NewGuid().ToString() + "." +ext

                };

            uploadResult = this.cloudinaryUtility.Upload(uploadParams);
        }

            return uploadResult?.SecureUri.AbsoluteUri;
        }
}
}

