using Microsoft.AspNetCore.Mvc;

namespace HeavensHall.Commerce.Web.Controllers
{
    public class EmployeeController : Controller
    {
        [Route("gerenciar")]
        public IActionResult HomePage()
        {
            return View("EmployeeHomePage");
        }
    }
}
