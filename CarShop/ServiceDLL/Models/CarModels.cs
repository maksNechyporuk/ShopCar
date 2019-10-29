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
        public int Price { get; set; }
        public List<FNameGetViewModel> filters { get; set; }
    }
    public class CarAddVM
    {

    }
    public class CarDeleteVM
    {
        public int Id { get; set; }
    }
}
