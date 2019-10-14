using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceDLL.Models
{
        public class UserLoginVM
        {
            public string Email { get; set; }

            public string Password { get; set; }
        }

        public class UserRegisterVM
        {
            public string Name { get; set; }

            public string Email { get; set; }

            public string Password { get; set; }
        }
}
