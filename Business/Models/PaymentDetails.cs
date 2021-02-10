using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Business.Models
{
    public class PaymentDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public Guid ID { get; set; }

        [Required]
        //[Column(TypeName ="nvachar(100)")]
        public string BankName { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string AccountNumber { get; set; }
        //[Required]
        //public string Currency { get; set; }
        [Required]
        public string AccountExpiryDate { get; set; }
        [Required]
        public string AccountSecurityNumber { get; set; }



    }
}
