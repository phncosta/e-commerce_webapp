using HeavensHall.Commerce.Application.DTOs;
using HeavensHall.Commerce.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HeavensHall.Commerce.Application.Interfaces.Service
{
    public interface IProductService
    {
        Task<Product> RegisterProduct(ProductDTO productDto);
        Task UpdateProduct(ProductDTO productDto);
        Task<Product> GetProductData(int id);
        Task<ProductDetail> GetProductWithDetails(int id);
        Task<Stock> GetStockFromProduct(int id);
        Task<List<Product>> GetProductsDataList();
        Task<List<ProductDetail>> GetAllProducstWithDetails();
        Task<List<ProductDetail>> GetAllProductsFilteredByIndex(int startIndex, int maxRows);
        Task AddProductImage(ProductImage productImage);
        Task<List<ProductImage>> GetMainImageFromProduct(int id);
        Task<List<ProductImage>> GetAllImagesFromProduct(int productId);
    }
}