using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace NetflixClone.Web.Helpers
{
    public class FileUploadHelper : IFileUploadHelper
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public FileUploadHelper(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public string UploadFile(IFormFile file)
        {
            string uniqueFilename = null;
            if (file != null)
            {
                string uploadFolder = Path.Combine(_webHostEnvironment.WebRootPath, "videos");
                uniqueFilename = Guid.NewGuid().ToString() + "_" + file.FileName;
                string filePath = Path.Combine(uploadFolder, uniqueFilename);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
            }

            return uniqueFilename;
        }
    }
}
