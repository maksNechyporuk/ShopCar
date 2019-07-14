using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Entities
{
    [Table("tblOrders")]
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]

        public float Price { get; set; }


        [ForeignKey("Car")]
        public int CarId { get; set; }

        public virtual Car Car { get; set; }

        [ForeignKey("Client")]
        public int ClientId { get; set; }

        public virtual Client Client { get; set; }
    }
}
