using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceDLL.Models
{
    public class ModelVM
    {
        public int Id { get; set; }

        public MakeVM Make { get; set; }
        public string Name { get; set; }
    }
    public class ModelAddVM
    {
        public MakeVM Make { get; set; }
        public string Name { get; set; }
    }
    public class ModelException
    {
        public string Make { get; set; }
        public string Name { get; set; }
    }
    public class ModelDeleteVM
    {
        public int Id { get; set; }
    }
}
