using ServiceDLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceDLL.Interfaces
{
    interface ICarService
    {
        CarVM GetCarsByName(string Name );
        Task<CarVM> GetCarsByNameAsync(string Name);

        List<CarVM> GetCars();
        Task<List<CarVM>> GetCarsAsync();
        List<CarVM> GetCarsByFilters(int [] id);
        Task<List<CarVM>> GetCarsByFiltersAsync(int[] id);
        string Create(CarAddVM model);
        string Delete(CarDeleteVM model);
        string Update(CarVM model);
        Task<string> DeleteAsync(CarDeleteVM model);
        Task<string> CreateAsync(CarAddVM model);
        Task<string> UpdateAsync(CarVM model);
    }
}
