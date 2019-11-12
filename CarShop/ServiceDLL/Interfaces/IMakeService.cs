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

        int GetMakeByModels(int model);
        Task<int> GetMakeByModelsAsync(int model);
        List<MakeVM> GetMakes(string make);
        Task<List<MakeVM>> GetMakesAsync(string make);
        string Create(MakeAddModel make);
        string Delete(MakelDeleteVM make);
        string Update(MakeVM make);
        Task<string> CreateAsync(MakeAddModel make);
        Task<string> DeleteAsync(MakelDeleteVM make);
        Task<string> UpdateAsync(MakeVM make);
    }
}
