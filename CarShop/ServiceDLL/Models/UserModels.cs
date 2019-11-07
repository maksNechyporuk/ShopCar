using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceDLL.Models
{
        public class UserVM
        {
            public int Id { get; set; }

            public string Name { get; set; }
        
            public string Email { get; set; }
        }
        public class UserLoginVM
        {
            public string Name { get; set; }

            public string Password { get; set; }
        }

        public class UserRegisterVM
        {
            public string Name { get; set; }

            public string Email { get; set; }

            public string Password { get; set; }
        }

        public class UserDeleteVM
        {
            public int Id { get; set; }
        }

        public class UserUpdateVM
        {
            public int Id { get; set; }
        
            public string Name { get; set; }
        
            public string Email { get; set; }
        
        }
}
