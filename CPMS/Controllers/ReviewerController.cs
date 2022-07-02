using Microsoft.AspNetCore.Mvc;

namespace CPMS.Controllers
{
    public class ReviewerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
