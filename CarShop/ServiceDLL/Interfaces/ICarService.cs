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
        List<CarsByFilterVM> GetCarsByFilterSearch(int[] id, string name);
        Task<List<CarsByFilterVM>> GetCarsByFilterSearchAsync(int[] id, string name);        
        CarUpdateVM GetCarForUpdate(int CarId);
        Task<CarUpdateVM> GetCarForUpdateAsync(int CarId);
        string CreateFilterWithCars(FilterAddWithCarVM model);
        Task<string> CreateAsyncFilterWithCars(FilterAddWithCarVM model);
        CarVM GetCarsByName(string Name );
        Task<CarVM> GetCarsByNameAsync(string Name);
        List<FNameViewModel> GetModelsByMake(int id);
        Task<List<FNameViewModel>> GetModelsByMakeAsync(int id);
        List<CarsByFilterVM> GetCars();
        Task<List<CarsByFilterVM>> GetCarsAsync();
        List<CarsByFilterVM> GetCarsByFilters(int [] id);
        Task<List<CarsByFilterVM>> GetCarsByFiltersAsync(int[] id);
        int Create(CarAddVM model);
        string Delete(CarDeleteVM model);
        int Update(CarAddVM model);
        Task<string> DeleteAsync(CarDeleteVM model);
        Task<int> CreateAsync(CarAddVM model);
        Task<int> UpdateAsync(CarAddVM model);
        List<string> GetImagesBySize(string path, string size);
        Task<List<string>> GetImagesBySizeAsync(string path, string size);
    }
    
}
