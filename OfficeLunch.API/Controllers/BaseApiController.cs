using Microsoft.AspNetCore.Mvc;

namespace OfficeLunch.API.Controllers
{
    public class BaseApiController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
