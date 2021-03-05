using Microsoft.AspNetCore.Mvc;

namespace HeavensHall.Commerce.Web.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Home() => View("Users/Admin/Home");
    }
}
