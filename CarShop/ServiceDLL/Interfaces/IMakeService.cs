using ServiceDLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceDLL.Interfaces
{
    public interface IMakeService
    {
        List<MakeModels> GetMakes();
        Task<List<MakeModels>> GetMakesAsync();
        void Create(MakeAddModel make);
    }
}
