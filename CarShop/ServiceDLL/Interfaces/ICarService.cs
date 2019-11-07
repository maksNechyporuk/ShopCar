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
        List<FNameViewModel> GetModelsByMake(int id);
        List<FNameViewModel> GetModelsByMakeAsync(int id);
        List<CarsByFilterVM> GetCars();
        Task<List<CarsByFilterVM>> GetCarsAsync();
        List<CarsByFilterVM> GetCarsByFilters(int [] id);
        Task<List<CarsByFilterVM>> GetCarsByFiltersAsync(int[] id);
        string Create(CarAddVM model);
        string Delete(CarDeleteVM model);
        string Update(CarVM model);
        Task<string> DeleteAsync(CarDeleteVM model);
        Task<string> CreateAsync(CarAddVM model);
        Task<string> UpdateAsync(CarVM model);
        List<string> GetImagesBySize(string path, string size);
        Task<List<string>> GetImagesBySizeAsync(string path, string size);
    }
    
}
