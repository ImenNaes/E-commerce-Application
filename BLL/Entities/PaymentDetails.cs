using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BLL.Entities
{
    public class PaymentDetails
    {
        [Key]
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
     
        //public virtual Profile Profile { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? UpdateDate { get; set; }

        public PaymentDetails()
        {
            ID = Guid.NewGuid();
            CreationDate = DateTime.Now;
            UpdateDate = DateTime.Now;
        }

    }
}
