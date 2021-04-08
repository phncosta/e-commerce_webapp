using HeavensHall.Commerce.Application.DTOs;
using HeavensHall.Commerce.Application.Extensions.EnumExtensions;
using HeavensHall.Commerce.Application.Interfaces.Service;
using HeavensHall.Commerce.Domain.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace HeavensHall.Commerce.Infrastructure.Services
{
    public class ImageService : IImageService
    {
        const string PRODUCT_IMG_FOLDER = "img\\products\\category";

        public string GetImageFolderByCategory(string categoryName)
        {
            var instrumentCategory = Enum.GetValues(typeof(InstrumentCategory))
                                         .Cast<InstrumentCategory>()
                                         .FirstOrDefault(c => c.GetDescription() == categoryName);

            var imgFolder = Path.Combine(PRODUCT_IMG_FOLDER, instrumentCategory.ToString().ToLower());

            return imgFolder;
        }

        public List<ImageDTO> GetImageDataListFromArray(string[] imagesDTO)
        {
            var imagesData = new List<ImageDTO>();

            foreach (var image in imagesDTO)
            {
                imagesData = JsonSerializer.Deserialize<List<ImageDTO>>(image);
            }

            return imagesData;
        }
    }
}
