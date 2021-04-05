﻿using AutoMapper;
using HeavensHall.Commerce.Application.DTOs;
using HeavensHall.Commerce.Application.Interfaces.Service;
using HeavensHall.Commerce.Domain.Entities;
using HeavensHall.Commerce.Infrastructure.Files;
using HeavensHall.Commerce.Infrastructure.Identity;
using HeavensHall.Commerce.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace HeavensHall.Commerce.Web.Controllers
{
    [Route("produtos")]
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        private readonly IImageService _imageService;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;

        public ProductsController(IProductService productService,
                                  IMapper mapper,
                                  IImageService imageService,
                                  UserManager<ApplicationUser> userManager)
        {
            _productService = productService;
            _imageService = imageService;
            _mapper = mapper;
            _userManager = userManager;
        }

        public IActionResult Index() => View();

        [Authorize(Roles = "Admin")]
        [Route("cadastrar")]
        public IActionResult ProductRegistration() => View("ProductRegistration");

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [Route("cadastrar")]
        public async Task<IActionResult> SendProductRegistration(ProductDTO productDTO)
        {
            var registerProduct = _productService.RegisterProduct(productDTO);
            var imgFolderPath = _imageService.GetImageFolderByCategory(productDTO.Category_Name);
            var imageList = _imageService.GetImageDataListFromArray(productDTO.Images);

            Product product = await registerProduct;

            foreach (var image in imageList)
            {
                var addProductImage = _productService.AddProductImage(new ProductImage()
                {
                    Product = product,
                    Path = Path.Combine(imgFolderPath, image.Name),
                    Main = image.Main
                });

                FileManagement.SaveImage(image.Base64, image.Name, imgFolderPath);
                await addProductImage;
            }

            return RedirectToAction("ProductRegistration");
        }

        [Authorize(Roles = "Admin")]
        [Route("alterar")]
        public async Task<IActionResult> ProductUpdate(int id)
        {
            var productDetail = await _productService.GetProductWithDetails(id);
            var stock = await _productService.GetStockFromProduct(id);

            var productModel = _mapper.Map<ProductModel>(productDetail);
            productModel.Stock = _mapper.Map<StockModel>(stock);

            return View("ProductUpdate", productModel);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
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

            var productImages = await _productService.GetAllImagesFromProduct(id);
            productModel.Images = _mapper.Map(productImages, new List<ProductImageModel>());

            return View("ProductDetails", productModel);
        }

        [Authorize(Roles = "Admin")]
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
