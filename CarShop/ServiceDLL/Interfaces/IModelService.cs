using ServiceDLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceDLL.Interfaces
{
  public  interface IModelService
    {
        List<ModelVM> GetModels(string make);
        Task<List<ModelVM>> GetModelsAsync(string make);
        string Create(ModelAddVM make);
        string Delete(ModelDeleteVM make);
        string Update(ModelVM make);
        Task<string> CreateAsync(ModelAddVM make);
        Task<string> DeleteAsync(ModelDeleteVM make);
        Task<string> UpdateAsync(ModelVM make);
    }
}
