using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CPMS.Models
{
    public static class UserModel
    {
        public static string EmailAddress { get; set; }

        public static string Password { get; set; }

        public static int userID { get; set; }

        public static bool userType { get; set; }

        public static bool valid { get; set; }
    }
}
