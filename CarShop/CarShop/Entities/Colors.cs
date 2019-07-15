using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Entities
{
    [Table("tblColors")]
   public class Colors
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public int A { get; set; }
        [Required]
        public int R{ get; set; }
        [Required]
        public int G { get; set; }
        [Required]
        public int B { get; set; }
   

    }
}
