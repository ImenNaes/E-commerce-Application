using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BLL.Entities
{
    public class Payment
    {
        [Key]
        public Guid ID { get; set; }
        [Required]
        public string IBAN { get; set; }
        [Required]

        public string RIB { get; set; }
        [Required]
        //[Column(TypeName ="nvachar(100)")]
        public string BankName { get; set; }

        //public PaymentStatus PaymentStatus { get; set; }

        //public Guid PaymentDetailsID { get; set; }
        //[Required]
        //public IEnumerable<PaymentDetails> PaymentDetails { get; set; }
        //public Guid ProductID { get; set; }
        //[Required]
        //public IEnumerable<Product> Produtcs { get; set; }
      
        public virtual Profile Profile { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? UpdateDate { get; set; }

        public Payment()
        {
            ID = Guid.NewGuid();
            CreationDate = DateTime.Now;
            UpdateDate = DateTime.Now;
        }
    }
}
