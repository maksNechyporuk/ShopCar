using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceDLL.Models
{
    public class ClientVM
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public string UniqueName { get; set; }

        public string Image { get; set; }

        public string Email { get; set; }
    }
    public class ClientDataGridVM
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }
        public string UniqueName { get; set; }

        public string Email { get; set; }

    }
    public class ClientAddVM
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Image { get; set; }
        public string UniqueName { get; set; }
        public string Email { get; set; }
    }
    public class ClientDeleteVM
    {
        public int Id { get; set; }
    }
}
