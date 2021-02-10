using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portail.Models
{
    public class Invoice
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public Guid ID { get; set; }
        [Required]
        public Guid UserID { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual Payment Payment { get; set; }
    }
}
