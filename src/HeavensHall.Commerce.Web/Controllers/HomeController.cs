using AutoMapper;
using HeavensHall.Commerce.Application.Interfaces;
using HeavensHall.Commerce.Application.Interfaces.Service;
using HeavensHall.Commerce.Domain.Entities;
using HeavensHall.Commerce.Models;
using HeavensHall.Commerce.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
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
        private const int PRODUCTS_TO_SELECT = 8;

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
            var productsDetailed = await _productService.GetAllProductDetailsByNumberOfRows(0, PRODUCTS_TO_SELECT); 
            var products = _mapper.Map(productsDetailed, new List<ProductModel>());

            foreach (var product in products)
            {
                var stock = await _productService.GetStockFromProduct(product.Id);
                product.Stock = _mapper.Map<StockModel>(stock);
            }

            return View("Index", products);
        }

        [Route("pagina")]
        public async Task<IActionResult> Pagination(int num)
        {
            int maxRowIndex = num * PRODUCTS_TO_SELECT;
            int minRowIndex = maxRowIndex - PRODUCTS_TO_SELECT;

            var productsDetailed = await _productService.GetAllProductDetailsByNumberOfRows(minRowIndex, maxRowIndex);
            var products = _mapper.Map(productsDetailed, new List<ProductModel>());

            foreach (var product in products)
            {
                var stock = await _productService.GetStockFromProduct(product.Id);
                product.Stock = _mapper.Map<StockModel>(stock);
            }

            return View("Index", products);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
