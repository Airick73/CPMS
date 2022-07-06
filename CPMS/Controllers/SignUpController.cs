using Microsoft.AspNetCore.Mvc;
using CPMS.Services;
using CPMS.Models;

namespace CPMS.Controllers
{
    public class SignUpController : Controller
    {
        AddData addData = new AddData();

        public IActionResult Index() { return View(); }
        public IActionResult RegisterAuthor() { return View(); }
        public IActionResult RegisterReviewer() { return View(); }


        public IActionResult RegisterAuthorData(AuthorModel author)
        {
            addData.AddAuthor(author);
            return RedirectToAction("Index", "Login");
        }

        public IActionResult RegisterReviewerData(ReviewerModel reviewer)
        {
            addData.AddReviewer(reviewer);
            return RedirectToAction("Index", "Login");
        }
    }
}
