using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceDLL.Data
{
    public class EFContext : DbContext
    {
        static EFContext()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<EFContext, ContextMigrationConfiguration>(true));
        }

        public EFContext() : base ("DefaultConnection")
        {

        }
        //public EFContext(DbConnection connection) : base(connection, false)
        //{ }

        public DbSet<Credential> Credentials { get; set; }
    }
}
