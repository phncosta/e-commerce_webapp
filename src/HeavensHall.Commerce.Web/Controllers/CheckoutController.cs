using HeavensHall.Commerce.Application.DTOs;
using HeavensHall.Commerce.Application.Interfaces.Service;
using HeavensHall.Commerce.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace HeavensHall.Commerce.Web.Controllers
{
    [Route("checkout")]
    public class CheckoutController : Controller
    {
        private readonly IProductService _productService;

        public CheckoutController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Checkout() => View();

        [HttpPost("produtos")]
        public async Task<IActionResult> Checkout([FromBody] List<CartProductDTO> cartProductDto)
        {
            foreach (var cartProduct in cartProductDto)
            {
                var product = await _productService.GetProductData(int.Parse(cartProduct.Id));
                var mainImage = await _productService.GetMainImageFromProduct(product.Id);
                cartProduct.Price = product.Price.ToString();
                cartProduct.Image = mainImage[0].Path;
                cartProduct.Name = product.Name;
                cartProduct.Brand = product.Brand.Name;
            }

            return Json(JsonSerializer.Serialize(cartProductDto));
        }
    }
}
