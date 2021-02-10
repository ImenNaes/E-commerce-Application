using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Business.Models
{
    public class Payment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

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
    }
}
