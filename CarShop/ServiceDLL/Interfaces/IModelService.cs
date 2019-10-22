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
        List<ModelVM> GetModel();
        Task<List<ModelVM>> GetModelAsync();
        void Create(ModelAddVM make);
        int Delete(ModelDeleteVM make);
        void Update(ModelVM make);
    }
}
