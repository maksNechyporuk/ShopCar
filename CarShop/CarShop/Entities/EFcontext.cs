using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Entities
{
   public class EFcontext :DbContext
    {
        public EFcontext():base("DefaultConnection")
        {
        }
        public DbSet<Colors> Colors { get; set; }
        public DbSet<Make> Makes { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<FuelType> FuelTypes { get; set; }
        public DbSet<TypeCar> TypeCars { get; set; }
        public DbSet<Car> Cars { get; set; }

        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Order> Orders { get; set; }

    }
}
