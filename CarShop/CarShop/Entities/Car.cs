using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Entities
{
    [Table("tblCars")]
    public class Car
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; }


        [ForeignKey("Color")]
        public int ColorId { get; set; }

        public virtual Colors Color { get; set; }


        [ForeignKey("Model")]
        public int ModelId { get; set; }

        public virtual Model Model { get; set; }

        [ForeignKey("FuelType")]
        public int FuelTypeId { get; set; }

        public virtual FuelType FuelType { get; set; }


        [ForeignKey("Type")]
        public int TypeId    { get; set; }

        public virtual TypeCar Type { get; set; }

       
        public string Image { get; set; }
        [Required]
        public int Price { get; set; }

     
    }
}
