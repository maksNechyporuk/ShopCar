using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Entities
{
    [Table("tblTypeCars")]
   public class TypeCar
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

    }
}
