using Microsoft.AspNetCore.Mvc;

namespace AbySalto.Mid.WebApi.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
