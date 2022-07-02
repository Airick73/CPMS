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
        public IActionResult Index()
        {
            return View();
        }

       public IActionResult ProcessLogin(UserModel user)
        {
            int userLoginType;
            UsersDAO usersDAO = new UsersDAO();
            userLoginType = usersDAO.FindUserByEmailAndPassword(user);

            if (userLoginType == 1) { return View(); }
            else if (userLoginType == 2) { return View(); }
            else { return View(); }

        }
    }
}
