using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceDLL.Models
{
    public class FValueViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class FNameGetViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public FValueViewModel Children { get; set; }
    }
    public class FNameViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<FValueViewModel> Children { get; set; }
    }

    public class FilterAddWithCarVM
    {
        public int IdCar { get; set; }
        public int[] IdValue { get; set; }
    }


    public class FilterAddVM
    {
        public string Name { get; set; }

    }
    public class FilterDeleteVM
    {
        public int Id { get; set; }
    }
}
