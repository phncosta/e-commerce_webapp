using Microsoft.AspNetCore.Mvc;

namespace HeavensHall.Commerce.Web.Controllers
{
    [Route("checkout")]
    public class CheckoutController : Controller
    {

        public IActionResult Checkout() => View();
    }
}
