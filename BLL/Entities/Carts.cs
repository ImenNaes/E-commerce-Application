using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BLL.Entities
{
    public class Carts
    {
        [Column(Order = 0)]
        [Key]
        public Guid ID { get; set; }      
        //public virtual Profile Profile { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string ai_Cart { get; set; }
        public int Quantity { get; set; }
        public Guid ProductID { get; set; }
        public virtual Product Products { get; set; }
        public decimal Price { get; set; }
        public Carts()
        {
            ID = Guid.NewGuid();
            CreationDate = DateTime.Now;
            UpdateDate = DateTime.Now;
        }
    }   
}
