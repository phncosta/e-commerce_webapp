using Microsoft.AspNetCore.Mvc;

namespace HeavensHall.Commerce.Web.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index() => View();

        public IActionResult ProductDetails() =>  View();
    }
}
