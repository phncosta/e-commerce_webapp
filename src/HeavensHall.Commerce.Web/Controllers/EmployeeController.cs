using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HeavensHall.Commerce.Web.Controllers
{
    [Route("gerenciar")]
    [Authorize(Roles = "Admin, Stockist")]
    public class EmployeeController : Controller
    {
        public IActionResult HomePage()
        {
            return View("EmployeeHomePage");
        }
    }
}
