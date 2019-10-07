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
        List<MakeModel> GetMakes();
        Task<List<MakeModel>> GetMakesAsync();
        void Create(MakeAddModel make);
        int Delete(ModelDeleteVM make);
        void Update(MakeModel make);
    }
}
