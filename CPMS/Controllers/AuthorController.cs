using Microsoft.AspNetCore.Mvc;

namespace CPMS.Controllers
{
    public class AuthorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
