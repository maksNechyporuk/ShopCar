using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Entities
{
    [Table("tblFuelTypes")]
  public  class FuelType
    {
        [Key]
        public int Id { get; set; }
      [Required]
        public string Type { get; set; }
    }
}
