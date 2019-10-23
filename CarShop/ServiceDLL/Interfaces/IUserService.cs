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
         string Login(UserLoginVM user);

        List<UserVM> GetUser();

        Task<List<UserVM>> GetUserAsync();

        string Register(UserRegisterVM user);
    }
}
