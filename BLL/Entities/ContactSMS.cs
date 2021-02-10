using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BLL.Entities
{
    public class ContactSMS
    {
        [Column(Order = 0)]
        [Key]
        public Guid ID { get; set; }
        [Required]       
        public string Name { get; set; }
        [EmailAddress]
        public string ToEmail { get; set; }
        [EmailAddress]
        public string FromEmail { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public bool Status { get; set; }       
        //public virtual Profile Profile { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? UpdateDate { get; set; }

        public ContactSMS()
        {
            ID = Guid.NewGuid();
            CreationDate = DateTime.Now;
            UpdateDate = DateTime.Now;
        }
    }
}
