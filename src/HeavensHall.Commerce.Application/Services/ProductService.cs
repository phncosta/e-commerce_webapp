using HeavensHall.Commerce.Application.Interfaces.Service;
using HeavensHall.Commerce.Application.Interfaces.Repository;
using System.Threading.Tasks;
using HeavensHall.Commerce.Domain.Entities;
using HeavensHall.Commerce.Application.DTOs;
using AutoMapper;
using System.Collections.Generic;

namespace HeavensHall.Commerce.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IProductRepository _productRepository;
        private readonly IStockRepository _stockRepository;
        private readonly IProductDetailRepository _productDetailRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductImageRepository _productImageRepository;
        private readonly IMapper _mapper;

        public ProductService(IBrandRepository brandRepository,
                              IProductRepository productRepository,
                              IStockRepository stockRepository,
                              IProductDetailRepository productDetailRepository,
                              ICategoryRepository categoryRepository,
                              IProductImageRepository productImageRepository,
                              IMapper mapper)
        {
            _brandRepository = brandRepository;
            _productRepository = productRepository;
            _stockRepository = stockRepository;
            _productDetailRepository = productDetailRepository;
            _categoryRepository = categoryRepository;
            _productImageRepository = productImageRepository;
            _mapper = mapper;
        }

        public async Task<Product> GetProductData(int productId) => await _productRepository.GetRelantionship(productId);

        public async Task<List<Product>> GetProductsDataList() => await _productRepository.GetAll();

        public async Task<ProductDetail> GetProductWithDetails(int productId) => await _productDetailRepository.GetProductRelationship(productId);

        public async Task<Stock> GetStockFromProduct(int productId) => await _stockRepository.GetByProductId(productId);

        public async Task<List<ProductDetail>> GetAllProducstWithDetails() => await _productDetailRepository.GetAllRelationships();

        public async Task UpdateStock(Stock stock) => await _stockRepository.Update(stock);

        public async Task<List<ProductImage>> GetMainImageFromProduct(int productId) => await _productImageRepository.GetMainImageByProduct(productId);

        public async Task<List<ProductDetail>> GetAllProductsFilteredByIndex(int startIndex, int maxRows) =>
                                                                     await _productDetailRepository.GetAllActiveProductRelationshipByIndex(startIndex, maxRows);

        public async Task<List<ProductImage>> GetAllImagesFromProduct(int productId) => await _productImageRepository.GetAllFromProduct(productId);

        public async Task AddProductImage(ProductImage productImage) => await _productImageRepository.Add(productImage);

        public async Task<Product> RegisterProduct(ProductDTO productDto)
        {
            var brand = await _brandRepository.GetOrInsert(productDto.Brand_Name);
            var category = await _categoryRepository.GetByName(productDto.Category_Name);

            var product = new Product()
            {
                Name = productDto.Product_Name,
                Description = productDto.Description,
                Price = productDto.Price,
                Brand = brand,
                Category = category,
                Is_Active = productDto.Is_Active
            };

            await _productRepository.Add(product);

            await _stockRepository.Add(new Stock()
            {
                Product = product,
                Quantity = productDto.Quantity
            });

            await _productDetailRepository.Add(new ProductDetail()
            {
                Rating = productDto.Rating,
                Product = product
            });

            return product;
        }

        public async Task UpdateProduct(ProductDTO productDto)
        {
            var productDetail = await _productDetailRepository.GetProductRelationship(productDto.Product_Id);

            productDetail = _mapper.Map(productDto, productDetail);
            productDetail.Product.Price = productDto.Price;
            productDetail.Product.Is_Active = productDto.Is_Active;
            productDetail.Product.Brand = await _brandRepository.GetOrInsert(productDto.Brand_Name);
            productDetail.Product.Category = await _categoryRepository.GetByName(productDto.Category_Name);

            await _productDetailRepository.Update(productDetail);

            var stock = await _stockRepository.GetByProductId(productDto.Product_Id);
            stock.Quantity = productDto.Quantity;

            await UpdateStock(stock);
        }
    }
}
