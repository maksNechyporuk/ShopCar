using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Entities
{
    [Table("tblPurchase")]
public    class Purchase
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Order")]
        public int OrderId { get; set; }

        public virtual Order Order { get; set; }

    }
}
