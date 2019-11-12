using ServiceDLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceDLL.Interfaces
{
    interface IFilterService
    {
        
        List<FNameViewModel> GetFilters();
        Task<List<FNameViewModel>> GetFiltersAsync();
        string Create(FilterAddVM name);
        string Delete(FilterDeleteVM filter);
        string Update(FNameViewModel filter);
        Task<string> DeleteAsync(FilterDeleteVM filter);
        Task<string> CreateAsync(FilterAddVM filter);
        Task<string> UpdateAsync(FNameViewModel filter);
    }
}
