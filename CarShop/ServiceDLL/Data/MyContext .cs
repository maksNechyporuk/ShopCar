using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceDLL.Data
{
    public class MyContext : DbContext
    {
        public MyContext() :base("DefaultConnection")
        {

        }
        public DbSet<Credential> Credentials { get; set; }
    }
}
