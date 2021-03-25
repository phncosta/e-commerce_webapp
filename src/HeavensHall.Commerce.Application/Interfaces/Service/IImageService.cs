using HeavensHall.Commerce.Application.DTOs;
using System.Collections.Generic;

namespace HeavensHall.Commerce.Application.Interfaces.Service
{
    public interface IImageService
    {
        List<ImageDTO> GetImageDataListFromArray(string[] images);
        string GetImageFolderByCategory(string category);
    }
}
