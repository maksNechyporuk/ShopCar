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
        List<MakeVM> GetMakes();
        Task<List<MakeVM>> GetMakesAsync();
        string Create(MakeAddModel make);
        int Delete(MakelDeleteVM make);
        void Update(MakeVM make);
    }
}
