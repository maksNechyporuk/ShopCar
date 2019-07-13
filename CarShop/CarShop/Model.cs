using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Entities
{
    [Table("tblModels")]
    public class Model
    {
        [Key]
        public int Id { get; set; }

        [Required]

        public string Name { get; set; }

        [ForeignKey("Make")]
        public int MakeId { get; set; }

        public virtual Make Make { get; set; }

    }
}
