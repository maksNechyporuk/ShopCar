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

        List<UserVM> GetUser(UserVM user);

        Task<List<UserVM>> GetUserAsync(UserVM user);

        string Register(UserRegisterVM user);

        string Delete(UserDeleteVM user);

        string Update(UserUpdateVM user);
    }
}
