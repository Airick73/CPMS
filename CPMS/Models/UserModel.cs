using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CPMS.Models
{
    public class UserModel
    {
        public string EmailAddress { get; set; }

        public string Password { get; set; }

        public string userID { get; set; }

        public bool userType { get; set; }
    }
}
