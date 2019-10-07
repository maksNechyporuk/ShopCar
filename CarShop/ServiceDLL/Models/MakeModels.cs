using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceDLL.Models
{
    public class MakeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class MakeAddModel
    {
        public string Name { get; set; }
    }
    public class ModelDeleteVM
    {
        public int Id { get; set; }
    }
}
