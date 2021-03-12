using System;
using System.IO;

namespace HeavensHall.Commerce.Infrastructure.Files
{
    public static class FileManagement
    {
        public static void SaveImage(string base64str, string imageName, string destinationFolder)
        {
            string _rootFolder = "wwwroot\\img";
            string path = $"{Environment.CurrentDirectory}\\{_rootFolder}\\{destinationFolder}";

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            
            string imgPath = Path.Combine(path, imageName);
            base64str = base64str.Split(";base64,")[1];

            File.WriteAllBytes(imgPath, Convert.FromBase64String(base64str));
        }
    }
}
