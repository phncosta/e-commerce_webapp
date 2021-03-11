using AutoMapper;
using HeavensHall.Commerce.Application.DTOs;
using HeavensHall.Commerce.Application.Interfaces.Service;
using HeavensHall.Commerce.Infrastructure.Files;
using HeavensHall.Commerce.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HeavensHall.Commerce.Web.Controllers
{
    [Route("produtos")]
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductsController(IProductService productService,
                                  IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        public IActionResult Index() => View();

        [Route("cadastrar")]
        public IActionResult ProductRegistration() => View("ProductRegistration");

        [HttpPost]
        [Route("cadastrar")]
        public async Task<IActionResult> SendProductRegistration(ProductDTO productDTO)
        {
            await _productService.RegisterProduct(productDTO);

            FileUploader.SaveImage(productDTO.Image_Base64, productDTO.Image_Path, $"products\\category\\{productDTO.Category_Name.ToLower()}");

            return RedirectToAction("ProductRegistration");
        }

        [Route("alterar")]
        public async Task<IActionResult> UpdateProduct(int id)
        {
            var productDetail = await _productService.GetProductWithDetails(id);
            var stock = await _productService.GetStockFromProduct(id);

            var productModel = _mapper.Map<ProductModel>(productDetail);
            productModel.Stock = _mapper.Map<StockModel>(stock);

            return View("ProductUpdate", productModel);
        }

        [HttpPost]
        [Route("alterar")]
        public async Task<IActionResult> SendProductUpdate(ProductModel productModel)
        {
            var productDto = _mapper.Map<ProductDTO>(productModel);

            await _productService.UpdateProduct(productDto);

            return RedirectToAction("Index", "Home");
        }

        [Route("{id}")]
        public async Task<IActionResult> ProductDetail(int id)
        {
            var productDetails = await _productService.GetProductWithDetails(id);
            var stock = await _productService.GetStockFromProduct(id);

            var productModel = _mapper.Map<ProductModel>(productDetails);
            productModel.Stock = _mapper.Map<StockModel>(stock);

            return View("ProductDetails", productModel);
        }

        [Route("gerenciar")]
        public async Task<IActionResult> ProductManagement()
        {
            var productsDetailed = await _productService.GetAllProducstWithDetails();

            var products = _mapper.Map(productsDetailed, new List<ProductModel>());

            foreach (var product in products)
            {
                var stock = await _productService.GetStockFromProduct(product.Id);
                product.Stock = _mapper.Map<StockModel>(stock);
            }

            return View("ProductManagement", products);
        }
    }
}
