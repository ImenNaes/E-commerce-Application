using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Entities
{
    public class Adress
    {
        [Key]
        public Guid Id { get; set; }
        [Column("Street")]
        public String Street { get; set; }
        [Column("Number")]
        public int Number { get; set; }
        [Column("City")]
        public String City { get; set; }
        [Column("PostalCode")]
        public String PostalCode { get; set; }
        //public virtual Profile Profile { get; set; }
        public Adress()
        {
            Id = Guid.NewGuid();
        }
    }
}
