using Microsoft.AspNetCore.Http;
using System.IO;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;

namespace Core.Utilities.FileOperation
{
    public static class FileOperation
    {

        public static string AddImageFile(IFormFile imageFile, IWebHostEnvironment env)
        {
            
            try
            {
                // \images\SavedPictures\
                string localeFile = @"images\SavedPictures";
                string uploads = Path.Combine(env.WebRootPath, localeFile);
                string fileFormat = Path.GetExtension(imageFile.FileName).ToLower();
                string fileName = Guid.NewGuid().ToString() + fileFormat;
                string filePath = Path.Combine(uploads, fileName);
                using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    imageFile.CopyTo(fileStream);
                    fileStream.Flush();
                }
                return @"\" + localeFile + @"\" + fileName;
            }
            catch (Exception)
            {
                return "";
            }
        }
        public static bool UpdateImageFile(IFormFile imageFile, string imagePath, IWebHostEnvironment env)
        {
            //www\images\SavedPictures\nil.jpg ==> kırmızı araba resim
            try
            {
                string path = env.WebRootPath + imagePath;
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    imageFile.CopyTo(fileStream);
                    fileStream.Flush();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool DeleteImagePath(string imagePath, IWebHostEnvironment env)
        {
            //www\images\SavedPictures\nil.jpg
            try
            {
                var path = env.WebRootPath + imagePath;
                if (File.Exists(path))
                {
                    File.Delete(path);

                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
