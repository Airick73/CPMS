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
        AddData addData = new AddData();
        public IActionResult Index()
        {
            return View();
        }

       public IActionResult ProcessLogin(UserModel user)
        {
            if (user.EmailAddress == "Admin" && user.Password == "adminpassword") { return RedirectToAction("Index", "Admin"); } //check if admin first

            UsersDAO usersDAO = new UsersDAO();
            user = usersDAO.FindUserByEmailAndPassword(user);

            if (user.userType == false && user.userID != null) { return RedirectToAction("Index", "Author", user); }
            else if (user.userType == true && user.userID != null) { return RedirectToAction("Index", "Reviewer", user); }
            else { return View("<h1>Invalid username or password.<h1/>"); }

        }

    }
}
