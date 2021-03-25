using System;
using System.IO;

namespace HeavensHall.Commerce.Infrastructure.Files
{
    public static class FileManagement
    {
        const string _rootFolder = "wwwroot";

        public static void SaveImage(string base64str, string imageName, string destinationFolder)
        {
            string directory = $"{_rootFolder}\\{destinationFolder}";

            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            
            string path = Path.Combine(_rootFolder, destinationFolder, imageName);
            base64str = base64str.Split(";base64,")[1];

            File.WriteAllBytes(path, Convert.FromBase64String(base64str));
        }
    }
}
