using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceDLL.Models
{
    public class CarVM
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
        public string UniqueName { get; set; }
        public string Name { get; set; }

        public List<FNameGetViewModel> filters { get; set; }
    }
    public class CarsByFilterVM
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }

        public string UniqueName { get; set; }
        public string Name { get; set; }
    }
    public class CarAddVM
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string MainImage { get; set; }
        public List<string> AdditionalImage { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
        public string UniqueName { get; set; }
        public string Name { get; set; }

    }
    public class CarUpdateVM       
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string MainImage { get; set; }
        public List<string> AdditionalImage { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
        public string UniqueName { get; set; }
        public string Name { get; set; }
        public FilterAddWithCarVM FilterAdd { get; set; }
    }
    public class CarDeleteVM
    {
        public int Id { get; set; }
    }
}
