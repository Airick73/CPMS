using CPMS.Models;
using CPMS.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CPMS.Controllers
{
    public class LoginController : Controller
    {
        GetPassword GetPassword = new GetPassword();
        public IActionResult Index()
        {
            return View();
        }

       public IActionResult ProcessLogin(AuthorModel auth)
        {
            UserModel.EmailAddress = auth.EmailAddress;
            UserModel.Password = auth.Password;
            if (UserModel.EmailAddress == "Admin" && UserModel.Password == "adminpassword") { return RedirectToAction("Index", "Admin"); } //check if admin first

            UsersDAO usersDAO = new UsersDAO();
            usersDAO.FindUserByEmailAndPassword();

            if (UserModel.userType == false && UserModel.valid == true) { return RedirectToAction("Index", "Author"); }
            else if (UserModel.userType == true && UserModel.valid == true) { return RedirectToAction("Index", "Reviewer"); }
            else { return View("<h1>Invalid username or password.<h1/>"); }

        }

        public IActionResult RetrievePassword()
        {
            return View();
        }

        public IActionResult SendPassword(AuthorModel author)
        {
            GetPassword.SendEmail(author.EmailAddress);
            return View("Index");
        }

    }
}
