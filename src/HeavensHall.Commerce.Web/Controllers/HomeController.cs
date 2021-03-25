using AutoMapper;
using HeavensHall.Commerce.Application.Interfaces.Service;
using HeavensHall.Commerce.Domain.Entities;
using HeavensHall.Commerce.Models;
using HeavensHall.Commerce.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace HeavensHall.Commerce.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        private readonly ILogger<HomeController> _logger;
        private const int MAX_PRODUCT_SELECTION = 8;

        public HomeController(IProductService productService,
                              IMapper mapper,
                              ILogger<HomeController> logger)
        {
            _productService = productService;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            List<ProductDetail> productsDetailed = await _productService.GetAllProductsFilteredByIndex(0, MAX_PRODUCT_SELECTION);

            return View("Index", await GetHomeProductModelList(productsDetailed));
        }

        [Route("pagina")]
        public async Task<IActionResult> Pagination(int num)
        {
            int maxRowSearchIndex = num * MAX_PRODUCT_SELECTION;
            int minRowSearchIndex = maxRowSearchIndex - MAX_PRODUCT_SELECTION;

            var productsDetailed = await _productService.GetAllProductsFilteredByIndex(minRowSearchIndex, maxRowSearchIndex);

            return View("Index", await GetHomeProductModelList(productsDetailed));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private async Task <List<ProductModel>> GetHomeProductModelList(List<ProductDetail> productDetailList)
        {
            List<ProductModel> productModelList = _mapper.Map(productDetailList, new List<ProductModel>());

            foreach (var productModel in productModelList)
            {
                var stock = await _productService.GetStockFromProduct(productModel.Id);
                productModel.Stock = _mapper.Map<StockModel>(stock);

                var productImages = await _productService.GetMainImageFromProduct(productModel.Id);
                productModel.Images = _mapper.Map(productImages, new List<ProductImageModel>());
            }

            return productModelList;
        }
    }
}
