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
        private readonly IMapper _mapper;

        public ProductService(IBrandRepository brandRepository,
                              IProductRepository productRepository,
                              IStockRepository stockRepository,
                              IProductDetailRepository productDetailRepository,
                              ICategoryRepository categoryRepository,
                              IMapper mapper)
        {
            _brandRepository = brandRepository;
            _productRepository = productRepository;
            _stockRepository = stockRepository;
            _productDetailRepository = productDetailRepository;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<Product> GetProductData(int id) =>  await _productRepository.GetRelantionship(id);

        public async Task<List<Product>> GetProductsData() => await _productRepository.GetAll();

        public async Task<ProductDetail> GetProductWithDetails(int id) => await _productDetailRepository.GetProductRelationship(id);

        public async Task<Stock> GetStockFromProduct(int id) => await _stockRepository.GetByProductId(id);

        public async Task<List<ProductDetail>> GetAllProducstWithDetails() => await _productDetailRepository.GetAllRelationships();

        public async Task UpdateStock(Stock stock) => await _stockRepository.Update(stock);

        public async Task<List<ProductDetail>> GetAllProductDetailsByNumberOfRows(int startIndex, int maxRows) =>
                     await _productDetailRepository.GetAllActiveProductRelationshipByPage(startIndex, maxRows);

        public async Task RegisterProduct(ProductDTO productDto)
        {
            var brand = await _brandRepository.GetOrInsert(productDto.Brand_Name);
            var category = _categoryRepository.GetByName(productDto.Category_Name);

            var product = new Product()
            {
                Name = productDto.Product_Name,
                Description = productDto.Description,
                Brand = brand,
                Category = category
            };

            await _productRepository.Add(product);

            await _stockRepository.Add(new Stock()
            {
                Product = product,
                Price = productDto.Price,
                Quantity = productDto.Quantity
            });

            await _productDetailRepository.Add(new ProductDetail()
            {
                Is_Active = true,
                Rating = productDto.Rating,
                Image_Path = $"{productDto.Category_Name.ToLower()}\\{productDto.Image_Path}",
                Product = product
            });
        }

        public async Task UpdateProduct(ProductDTO productDto)
        {
            var productDetail = await _productDetailRepository.GetProductRelationship(productDto.Product_Id);

            productDetail = _mapper.Map(productDto, productDetail);
            productDetail.Product.Brand = await _brandRepository.GetOrInsert(productDto.Brand_Name);
            productDetail.Product.Category = _categoryRepository.GetByName(productDto.Category_Name);

            await _productDetailRepository.Update(productDetail);

            var stock = await _stockRepository.GetByProductId(productDto.Product_Id);
            stock.Price = productDto.Price;
            stock.Quantity = productDto.Quantity;

            await UpdateStock(stock);
        }
    }
}
