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
                Name = "Black",
                R = 0,
                G = 0,
                B = 0,
                A = 1
            });

            context.Colors.AddOrUpdate(a => a.Id, new Entities.Colors
            {
                Id = 4,
                Name = "White",
                R = 255,
                G = 255,
                B = 255,
                A = 1
            });

            context.Colors.AddOrUpdate(a => a.Id, new Entities.Colors
            {
                Id = 5,
                Name = "Beige",
                R = 245,
                G = 245,
                B = 220,
                A = 1
            });

            context.Colors.AddOrUpdate(a => a.Id, new Entities.Colors
            {
                Id = 6,
                Name = "Blue",
                R = 0,
                G = 0,
                B = 255,
                A = 1
            });

            context.Colors.AddOrUpdate(a => a.Id, new Entities.Colors
            {
                Id = 7,
                Name = "Brown",
                R = 205,
                G = 133,
                B = 63,
                A = 1
            });

            context.Colors.AddOrUpdate(a => a.Id, new Entities.Colors
            {
                Id = 8,
                Name = "Grey",
                R = 128,
                G = 128,
                B = 128,
                A = 1
            });

            context.Colors.AddOrUpdate(a => a.Id, new Entities.Colors
            {
                Id = 9,
                Name = "Orange",
                R = 255,
                G = 165,
                B = 0,
                A = 1
            });

            context.Colors.AddOrUpdate(a => a.Id, new Entities.Colors
            {
                Id = 10,
                Name = "Purple",
                R = 238,
                G = 130,
                B = 238,
                A = 1
            });

            context.Colors.AddOrUpdate(a => a.Id, new Entities.Colors
            {
                Id = 10,
                Name = "Yellow",
                R = 255,
                G = 255,
                B = 0,
                A = 1
            });

            #endregion
            #region tblFuelTypes

            context.FuelTypes.AddOrUpdate(a => a.Id, new Entities.FuelType
            {
                Id = 1,
                Type = "Electric"
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
                Type = "Gasoline"
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
                Name = "Hyundai"
            });

            context.Makes.AddOrUpdate(a => a.Id, new Entities.Make
            {
                Id = 13,
                Name = "Opel"
            });

            context.Makes.AddOrUpdate(a => a.Id, new Entities.Make
            {
                Id = 14,
                Name = "Renault"
            });

            context.Makes.AddOrUpdate(a => a.Id, new Entities.Make
            {
                Id = 15,
                Name = "Subaru"
            });

            context.Makes.AddOrUpdate(a => a.Id, new Entities.Make
            {
                Id = 16,
                Name = "Skoda"
            });

            context.Makes.AddOrUpdate(a => a.Id, new Entities.Make
            {
                Id = 17,
                Name = "Honda"
            });

            context.Makes.AddOrUpdate(a => a.Id, new Entities.Make
            {
                Id = 18,
                Name = "Citroen"
            });

            #endregion
            #region tblClients          
            context.Clients.AddOrUpdate(a => a.Id, new Entities.Client
            {
                Id = 1,
                Name = "Zahar",
                Phone = "+380(68)238-80-01",
                Image = "https://mystatfiles.itstep.org/index.php?view_key=rtILv2awXkYrSQ7WVzOr0G9F1kZwIdRQC03dLrvYiKeqOlHfVfWihS%2FQG%2F11CgvGz2Oj7lb%2FU37S6VWM25ADRgZpjRgGmn2pOd45FJeYozc%3D"

            });

            context.Clients.AddOrUpdate(a => a.Id, new Entities.Client
            {
                Id = 2,
                Name = "Yuri",
                Phone = "+380(68)278-55-22",
                Image = "https://mystatfiles.itstep.org/index.php?view_key=rtILv2awXkYrSQ7WVzOr0G9F1kZwIdRQC03dLrvYiKeqOlHfVfWihS%2FQG%2F11CgvGz2Oj7lb%2FU37S6VWM25ADRgZpjRgGmn2pOd45FJeYozc%3D"

            });

            context.Clients.AddOrUpdate(a => a.Id, new Entities.Client
            {
                Id = 3,
                Name = "Maxim",
                Phone = "+380(97)888-15-97",
                Image = "https://mystatfiles.itstep.org/index.php?view_key=rtILv2awXkYrSQ7WVzOr0G9F1kZwIdRQC03dLrvYiKeqOlHfVfWihS%2FQG%2F11CgvGz2Oj7lb%2FU37S6VWM25ADRgZpjRgGmn2pOd45FJeYozc%3D"

            });

            context.Clients.AddOrUpdate(a => a.Id, new Entities.Client
            {
                Id = 4,
                Name = "Man",
                Phone = "+380(97)156-75-36",
                Image = "https://mystatfiles.itstep.org/index.php?view_key=rtILv2awXkYrSQ7WVzOr0G9F1kZwIdRQC03dLrvYiKeqOlHfVfWihS%2FQG%2F11CgvGz2Oj7lb%2FU37S6VWM25ADRgZpjRgGmn2pOd45FJeYozc%3D"

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

            context.Models.AddOrUpdate(a => a.Id, new Entities.Model
            {
                Id = 12,
                MakeId = 4,
                Name = "A SEDAN"
            });

            context.Models.AddOrUpdate(a => a.Id, new Entities.Model
            {
                Id = 13,
                MakeId = 4,
                Name = "V-CLASS"
            });

            context.Models.AddOrUpdate(a => a.Id, new Entities.Model
            {
                Id = 14,
                MakeId = 4,
                Name = "M-CLASS"
            });

            context.Models.AddOrUpdate(a => a.Id, new Entities.Model
            {
                Id = 15,
                MakeId = 4,
                Name = "S-CLASS CABRIOLET"
            });

            context.Models.AddOrUpdate(a => a.Id, new Entities.Model
            {
                Id = 16,
                MakeId = 5,
                Name = "GT 86"
            });

            context.Models.AddOrUpdate(a => a.Id, new Entities.Model
            {
                Id = 17,
                MakeId = 5,
                Name = "SIENNA"
            });

            context.Models.AddOrUpdate(a => a.Id, new Entities.Model
            {
                Id = 18,
                MakeId = 5,
                Name = "CAMRY"
            });

            context.Models.AddOrUpdate(a => a.Id, new Entities.Model
            {
                Id = 19,
                MakeId = 6,
                Name = "GOLF"
            });

            context.Models.AddOrUpdate(a => a.Id, new Entities.Model
            {
                Id = 20,
                MakeId = 6,
                Name = "ATLAS"
            });

            context.Models.AddOrUpdate(a => a.Id, new Entities.Model
            {
                Id = 21,
                MakeId = 6,
                Name = "PASSAT"
            });

            context.Models.AddOrUpdate(a => a.Id, new Entities.Model
            {
                Id = 22,
                MakeId = 6,
                Name = "TOURAN"
            });

            context.Models.AddOrUpdate(a => a.Id, new Entities.Model
            {
                Id = 23,
                MakeId = 7,
                Name = "COBALT"
            });

            context.Models.AddOrUpdate(a => a.Id, new Entities.Model
            {
                Id = 24,
                MakeId = 7,
                Name = "CORVETTE"
            });

            context.Models.AddOrUpdate(a => a.Id, new Entities.Model
            {
                Id = 25,
                MakeId = 7,
                Name = "VIVA"
            });

            context.Models.AddOrUpdate(a => a.Id, new Entities.Model
            {
                Id = 26,
                MakeId = 7,
                Name = "ORLANDO"
            });

            context.Models.AddOrUpdate(a => a.Id, new Entities.Model
            {
                Id = 27,
                MakeId = 7,
                Name = "ALERO"
            });

            context.Models.AddOrUpdate(a => a.Id, new Entities.Model
            {
                Id = 28,
                MakeId = 8,
                Name = "EXPLORER"
            });

            context.Models.AddOrUpdate(a => a.Id, new Entities.Model
            {
                Id = 29,
                MakeId = 8,
                Name = "FIESTA"
            });

            context.Models.AddOrUpdate(a => a.Id, new Entities.Model
            {
                Id = 30,
                MakeId = 8,
                Name = "FOCUS RS"
            });

            context.Models.AddOrUpdate(a => a.Id, new Entities.Model
            {
                Id = 31,
                MakeId = 8,
                Name = "MUSTANG"
            });

            context.Models.AddOrUpdate(a => a.Id, new Entities.Model
            {
                Id = 32,
                MakeId = 8,
                Name = "TAURUS"
            });

            context.Models.AddOrUpdate(a => a.Id, new Entities.Model
            {
                Id = 33,
                MakeId = 9,
                Name = "EXPERT"
            });

            context.Models.AddOrUpdate(a => a.Id, new Entities.Model
            {
                Id = 34,
                MakeId = 9,
                Name = "308 GT"
            });

            context.Models.AddOrUpdate(a => a.Id, new Entities.Model
            {
                Id = 35,
                MakeId = 9,
                Name = "PEUGEOT 1007"
            });

            context.Models.AddOrUpdate(a => a.Id, new Entities.Model
            {
                Id = 36,
                MakeId = 9,
                Name = "208"
            });

            context.Models.AddOrUpdate(a => a.Id, new Entities.Model
            {
                Id = 37,
                MakeId = 9,
                Name = "TRAVELLER"
            });

            context.Models.AddOrUpdate(a => a.Id, new Entities.Model
            {
                Id = 38,
                MakeId = 9,
                Name = "508 RXH"
            });

            context.Models.AddOrUpdate(a => a.Id, new Entities.Model
            {
                Id = 39,
                MakeId = 10,
                Name = "BRAVO"
            });

            context.Models.AddOrUpdate(a => a.Id, new Entities.Model
            {
                Id = 40,
                MakeId = 10,
                Name = "MOBI"
            });

            context.Models.AddOrUpdate(a => a.Id, new Entities.Model
            {
                Id = 41,
                MakeId = 10,
                Name = "PANDA"
            });

            context.Models.AddOrUpdate(a => a.Id, new Entities.Model
            {
                Id = 42,
                MakeId = 10,
                Name = "TIPO"
            });

            context.Models.AddOrUpdate(a => a.Id, new Entities.Model
            {
                Id = 43,
                MakeId = 10,
                Name = "TORO"
            });

            context.Models.AddOrUpdate(a => a.Id, new Entities.Model
            {
                Id = 44,
                MakeId = 10,
                Name = "LINEA"
            });

            context.Models.AddOrUpdate(a => a.Id, new Entities.Model
            {
                Id = 45,
                MakeId = 11,
                Name = "LAFESTA"
            });

            context.Models.AddOrUpdate(a => a.Id, new Entities.Model
            {
                Id = 46,
                MakeId = 11,
                Name = "GT-R"
            });

            context.Models.AddOrUpdate(a => a.Id, new Entities.Model
            {
                Id = 47,
                MakeId = 11,
                Name = "ALMERA"
            });

            context.Models.AddOrUpdate(a => a.Id, new Entities.Model
            {
                Id = 48,
                MakeId = 11,
                Name = " PATROL"
            });

            context.Models.AddOrUpdate(a => a.Id, new Entities.Model
            {
                Id = 49,
                MakeId = 11,
                Name = "SENTRA"
            });

            context.Models.AddOrUpdate(a => a.Id, new Entities.Model
            {
                Id = 50,
                MakeId = 12,
                Name = "TERRACAN"
            });

            context.Models.AddOrUpdate(a => a.Id, new Entities.Model
            {
                Id = 51,
                MakeId = 12,
                Name = "KONA"
            });

            context.Models.AddOrUpdate(a => a.Id, new Entities.Model
            {
                Id = 52,
                MakeId = 12,
                Name = " GRANDEUR"
            });

            context.Models.AddOrUpdate(a => a.Id, new Entities.Model
            {
                Id = 53,
                MakeId = 12,
                Name = "CRETA"
            });

            context.Models.AddOrUpdate(a => a.Id, new Entities.Model
            {
                Id = 54,
                MakeId = 12,
                Name = "SONATA"
            });

            context.Models.AddOrUpdate(a => a.Id, new Entities.Model
            {
                Id = 55,
                MakeId = 12,
                Name = "GENESIS"
            });

            context.Models.AddOrUpdate(a => a.Id, new Entities.Model
            {
                Id = 56,
                MakeId = 13,
                Name = "ADAM"
            });

            context.Models.AddOrUpdate(a => a.Id, new Entities.Model
            {
                Id = 57,
                MakeId = 13,
                Name = "ANTARA"
            });

            context.Models.AddOrUpdate(a => a.Id, new Entities.Model
            {
                Id = 58,
                MakeId = 13,
                Name = "FRONTERA"
            });

            context.Models.AddOrUpdate(a => a.Id, new Entities.Model
            {
                Id = 59,
                MakeId = 13,
                Name = "CORSA"
            });

            context.Models.AddOrUpdate(a => a.Id, new Entities.Model
            {
                Id = 60,
                MakeId = 13,
                Name = "VIVARO"
            });

            context.Models.AddOrUpdate(a => a.Id, new Entities.Model
            {
                Id = 61,
                MakeId = 14,
                Name = "ESPACE"
            });

            context.Models.AddOrUpdate(a => a.Id, new Entities.Model
            {
                Id = 62,
                MakeId = 14,
                Name = "KOLEOS"
            });

            context.Models.AddOrUpdate(a => a.Id, new Entities.Model
            {
                Id = 63,
                MakeId = 14,
                Name = "LATITUDE"
            });

            context.Models.AddOrUpdate(a => a.Id, new Entities.Model
            {
                Id = 64,
                MakeId = 14,
                Name = "SANDERO"
            });

            context.Models.AddOrUpdate(a => a.Id, new Entities.Model
            {
                Id = 65,
                MakeId = 14,
                Name = "TALISMAN"
            });

            context.Models.AddOrUpdate(a => a.Id, new Entities.Model
            {
                Id = 66,
                MakeId = 14,
                Name = "TWINGO"
            });

            context.Models.AddOrUpdate(a => a.Id, new Entities.Model
            {
                Id = 67,
                MakeId = 15,
                Name = "STELLA"
            });

            context.Models.AddOrUpdate(a => a.Id, new Entities.Model
            {
                Id = 68,
                MakeId = 15,
                Name = "TRIBECA"
            });

            context.Models.AddOrUpdate(a => a.Id, new Entities.Model
            {
                Id = 69,
                MakeId = 15,
                Name = "ASCENT"
            });

            context.Models.AddOrUpdate(a => a.Id, new Entities.Model
            {
                Id = 70,
                MakeId = 15,
                Name = "JUSTY"
            });

            context.Models.AddOrUpdate(a => a.Id, new Entities.Model
            {
                Id = 71,
                MakeId = 15,
                Name = "FORESTER"
            });

            context.Models.AddOrUpdate(a => a.Id, new Entities.Model
            {
                Id = 72,
                MakeId = 16,
                Name = "CITIGO"
            });

            context.Models.AddOrUpdate(a => a.Id, new Entities.Model
            {
                Id = 73,
                MakeId = 16,
                Name = "OCTAVIA"
            });

            context.Models.AddOrUpdate(a => a.Id, new Entities.Model
            {
                Id = 74,
                MakeId = 16,
                Name = "ROOMSTER"
            });

            context.Models.AddOrUpdate(a => a.Id, new Entities.Model
            {
                Id = 75,
                MakeId = 16,
                Name = "YETI"
            });

            context.Models.AddOrUpdate(a => a.Id, new Entities.Model
            {
                Id = 76,
                MakeId = 16,
                Name = "KAMIQ"
            });

            context.Models.AddOrUpdate(a => a.Id, new Entities.Model
            {
                Id = 77,
                MakeId = 17,
                Name = "ACCORD"
            });

            context.Models.AddOrUpdate(a => a.Id, new Entities.Model
            {
                Id = 78,
                MakeId = 17,
                Name = "FIT"
            });

            context.Models.AddOrUpdate(a => a.Id, new Entities.Model
            {
                Id = 79,
                MakeId = 17,
                Name = "PASSPORT"
            });

            context.Models.AddOrUpdate(a => a.Id, new Entities.Model
            {
                Id = 80,
                MakeId = 17,
                Name = "PILOT"
            });

            context.Models.AddOrUpdate(a => a.Id, new Entities.Model
            {
                Id = 81,
                MakeId = 17,
                Name = "CR-V"
            });

            context.Models.AddOrUpdate(a => a.Id, new Entities.Model
            {
                Id = 82,
                MakeId = 18,
                Name = "C-CROSSER"
            });

            context.Models.AddOrUpdate(a => a.Id, new Entities.Model
            {
                Id = 83,
                MakeId = 18,
                Name = "BERLINGO"
            });

            context.Models.AddOrUpdate(a => a.Id, new Entities.Model
            {
                Id = 84,
                MakeId = 18,
                Name = "C4 SEDAN"
            });

            context.Models.AddOrUpdate(a => a.Id, new Entities.Model
            {
                Id = 85,
                MakeId = 18,
                Name = "SPACETOURER"
            });

            context.Models.AddOrUpdate(a => a.Id, new Entities.Model
            {
                Id = 86,
                MakeId = 18,
                Name = "C6"
            });

            #endregion
            #region tblTypesCar       
            context.TypeCars.AddOrUpdate(a => a.Id, new Entities.TypeCar
            {
                Id = 1,
                Name = "Passenger"

            });

            context.TypeCars.AddOrUpdate(a => a.Id, new Entities.TypeCar
            {
                Id = 2,
                Name = "Crossover"

            });

            context.TypeCars.AddOrUpdate(a => a.Id, new Entities.TypeCar
            {
                Id = 3,
                Name = "Truck"

            });

            context.TypeCars.AddOrUpdate(a => a.Id, new Entities.TypeCar
            {
                Id = 4,
                Name = "Moto"

            });
            #endregion
            #region tblCars     
            context.Cars.AddOrUpdate(a => a.Id, new Entities.Car
            {
                Id = 1,
                TypeId = 1,
                ModelId = 1,
                FuelTypeId = 3,
                Date = DateTime.Now,
                ColorId = 1,
                Image = "asd",
                Price = 50000

            });

            context.Cars.AddOrUpdate(a => a.Id, new Entities.Car
            {
                Id = 2,
                TypeId = 1,
                ModelId = 4,
                Date = DateTime.Now,
                FuelTypeId = 4,
                ColorId = 4,
                Price = 26000
            });

            context.Cars.AddOrUpdate(a => a.Id, new Entities.Car
            {
                Id = 3,
                TypeId = 1,
                ModelId = 2,
                FuelTypeId = 2,
                Date = DateTime.Now,
                ColorId = 1,
                Price = 15000
            });

            context.Cars.AddOrUpdate(a => a.Id, new Entities.Car
            {
                Id = 4,
                TypeId = 1,
                ModelId = 3,
                FuelTypeId = 2,
                Date = DateTime.Now,
                ColorId = 3,
                Price = 40000
            });

            context.Cars.AddOrUpdate(a => a.Id, new Entities.Car
            {
                Id = 5,
                TypeId = 1,
                ModelId = 2,
                FuelTypeId = 4,
                ColorId = 3,
                Date = DateTime.Now,
                Price = 10000
            });
            #endregion
        }
    }
}
