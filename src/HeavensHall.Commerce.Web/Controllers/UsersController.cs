using Microsoft.AspNetCore.Mvc;

namespace HeavensHall.Commerce.Web.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("home")]
        public IActionResult AdminHomePage()
        {
            return View();
        }
    }
}
