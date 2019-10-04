using ServiceDLL.Interfaces;
using ServiceDLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceDLL.Concrete
{
    class MakeApiService : IMakeService
    {
        void IMakeService.Create(MakeAddModel make)
        {
            throw new NotImplementedException();
        }

        List<MakeModels> IMakeService.GetMakes()
        {
            throw new NotImplementedException();
        }

        Task<List<MakeModels>> IMakeService.GetMakesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
