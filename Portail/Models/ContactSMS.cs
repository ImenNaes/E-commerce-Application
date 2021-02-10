using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portail.Models
{
    public class ContactSMS
    {
        [Column(Order = 0)]
        [Key]
        public Guid ID { get; set; }
        [Required]
        //public Guid UserID { get; set; }
        //[Required]
        //public DateTime CreatedDate { get; set; }
        //public DateTime? UpdatedDate { get; set; }
        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public bool Status { get; set; }
    }
}
