using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceDLL.Models
{
    public class OrderVM
    {
        public ClientVM Client { get; set; }
        public CarVM Car { get; set; }
    }
    public class OrderShowVM
    {
        public string Client { get; set; }
        public string Car { get; set; }
    }

    public class OrderAddVM
    {
        public ClientVM Client { get; set; }
        public CarVM Car { get; set; }
        public DateTime Date { get; set; }

    }


}
