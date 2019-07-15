namespace CarShop.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CarShop.Entities.EFcontext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CarShop.Entities.EFcontext context)
        {
            #region tblCars

            context.Cars.AddOrUpdate(a => a.Id, new Entities.Car
            {
                  
            });

            #endregion

            #region tblColors

            context.Colors.AddOrUpdate(a => a.Id, new Entities.Colors
            {
                Id = 1,
                Name = "Red",
                R = 255,
                G = 0,
                B = 0,
                A = 1
            });

            context.Colors.AddOrUpdate(a => a.Id, new Entities.Colors
            {
                Id = 2,
                Name = "Green",
                R = 0,
                G = 115,
                B = 0,
                A = 1
            });

            context.Colors.AddOrUpdate(a => a.Id, new Entities.Colors
            {
                Id = 3,
                Name = "Dark Blue",
                R = 0,
                G = 0,
                B = 228,
                A = 1
            });

            context.Colors.AddOrUpdate(a => a.Id, new Entities.Colors
            {
                Id = 4,
                Name = "Black",
                R = 0,
                G = 0,
                B = 0,
                A = 1
            });

            context.Colors.AddOrUpdate(a => a.Id, new Entities.Colors
            {
                Id = 5,
                Name = "White",
                R = 255,
                G = 255,
                B = 255,
                A = 1
            });

            #endregion

            #region tblFuelTypes

            context.FuelTypes.AddOrUpdate(a => a.Id, new Entities.FuelType
            {
                 Id = 1,
                 Type = "Electro"
            });

            context.FuelTypes.AddOrUpdate(a => a.Id, new Entities.FuelType
            {
                Id = 2,
                Type = "Gas"
            });

            context.FuelTypes.AddOrUpdate(a => a.Id, new Entities.FuelType
            {
                Id = 3,
                Type = "Diesel"
            });

            context.FuelTypes.AddOrUpdate(a => a.Id, new Entities.FuelType
            {
                Id = 4,
                Type = "Petrol"
            });

            #endregion

            #region tblModels

            context.Models.AddOrUpdate(a => a.Id, new Entities.Model
            {
                 Id = 1,
                 MakeId = 1,
                 Name = "3-series Coupe"
            });

            context.Models.AddOrUpdate(a => a.Id, new Entities.Model
            {
                Id = 2,
                MakeId = 1,
                Name = "750iL"
            });

            context.Models.AddOrUpdate(a => a.Id, new Entities.Model
            {
                Id = 3,
                MakeId = 1,
                Name = "X5"
            });

            context.Models.AddOrUpdate(a => a.Id, new Entities.Model
            {
                Id = 4,
                MakeId = 2,
                Name = "MX-5"
            });

            context.Models.AddOrUpdate(a => a.Id, new Entities.Model
            {
                Id = 5,
                MakeId = 2,
                Name = "Tribute"
            });

            context.Models.AddOrUpdate(a => a.Id, new Entities.Model
            {
                Id = 6,
                MakeId = 2,
                Name = "Axela"
            });

            context.Models.AddOrUpdate(a => a.Id, new Entities.Model
            {
                Id = 7,
                MakeId = 3,
                Name = "A5"
            });

            context.Models.AddOrUpdate(a => a.Id, new Entities.Model
            {
                Id = 8,
                MakeId = 3,
                Name = "Q2"
            });

            context.Models.AddOrUpdate(a => a.Id, new Entities.Model
            {
                Id = 9,
                MakeId = 3,
                Name = "S3"
            });

            context.Models.AddOrUpdate(a => a.Id, new Entities.Model
            {
                Id = 10,
                MakeId = 3,
                Name = "TTS"
            });

            context.Models.AddOrUpdate(a => a.Id, new Entities.Model
            {
                Id = 11,
                MakeId = 4,
                Name = "AMG GT S"
            });

            #endregion

            #region tblTypes

            context.TypeCars.AddOrUpdate(a => a.Id, new Entities.TypeCar
            {

            });

            #endregion

            #region tblMakes

            context.Makes.AddOrUpdate(a => a.Id, new Entities.Make
            {
                Id = 1,
                Name = "BMW"
            });

            context.Makes.AddOrUpdate(a => a.Id, new Entities.Make
            {
                Id = 2,
                Name = "Mazda"
            });

            context.Makes.AddOrUpdate(a => a.Id, new Entities.Make
            {
                Id = 3,
                Name = "Audi"
            });

            context.Makes.AddOrUpdate(a => a.Id, new Entities.Make
            {
                Id = 4,
                Name = "Mersedes-Benz"
            });

            context.Makes.AddOrUpdate(a => a.Id, new Entities.Make
            {
                Id = 5,
                Name = "Toyota"
            });

            context.Makes.AddOrUpdate(a => a.Id, new Entities.Make
            {
                Id = 6,
                Name = "Volkswagen"
            });

            context.Makes.AddOrUpdate(a => a.Id, new Entities.Make
            {
                Id = 7,
                Name = "Chevrolet"
            });

            context.Makes.AddOrUpdate(a => a.Id, new Entities.Make
            {
                Id = 8,
                Name = "Ford"
            });

            context.Makes.AddOrUpdate(a => a.Id, new Entities.Make
            {
                Id = 9,
                Name = "Peugeot"
            });

            context.Makes.AddOrUpdate(a => a.Id, new Entities.Make
            {
                Id = 10,
                Name = "Fiat"
            });

            context.Makes.AddOrUpdate(a => a.Id, new Entities.Make
            {
                Id = 11,
                Name = "Nissan"
            });

            context.Makes.AddOrUpdate(a => a.Id, new Entities.Make
            {
                Id = 12,
                Name = "Volvo"
            });

            context.Makes.AddOrUpdate(a => a.Id, new Entities.Make
            {
                Id = 13,
                Name = "Hyundai"
            });

            context.Makes.AddOrUpdate(a => a.Id, new Entities.Make
            {
                Id = 14,
                Name = "Opel"
            });

            context.Makes.AddOrUpdate(a => a.Id, new Entities.Make
            {
                Id = 15,
                Name = "Renault"
            });

            context.Makes.AddOrUpdate(a => a.Id, new Entities.Make
            {
                Id = 16,
                Name = "Seat"
            });

            context.Makes.AddOrUpdate(a => a.Id, new Entities.Make
            {
                Id = 17,
                Name = "Skoda"
            });

            context.Makes.AddOrUpdate(a => a.Id, new Entities.Make
            {
                Id = 18,
                Name = "Honda"
            });

            context.Makes.AddOrUpdate(a => a.Id, new Entities.Make
            {
                Id = 19,
                Name = "Citroen"
            });

            context.Makes.AddOrUpdate(a => a.Id, new Entities.Make
            {
                Id = 20,
                Name = "Suzuki"
            });

            #endregion

        }
    }
}
