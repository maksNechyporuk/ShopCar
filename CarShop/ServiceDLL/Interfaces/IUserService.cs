using ServiceDLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceDLL.Interfaces
{
    public interface IUserService
    {
         int Login(UserLoginVM user);

         int Register(UserRegisterVM user);
    }
}
