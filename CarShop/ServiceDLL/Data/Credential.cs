using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceDLL.Data
{
    [Table("tblCredentials")]
    public class Credential
    {
        [Key]
        public int Id { get; set; }
        [StringLength(1000), Required]
        public string Token { get; set; }
        [StringLength(255), Required]
        public string UserName { get; set; }
        public DateTime DateCreate { get; set; }
        public long DateExtToken { get; set; }
    }
}
